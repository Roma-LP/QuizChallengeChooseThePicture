using QuizChallenge.Scripts.Cells;
using QuizChallenge.Scripts.Scriptables;
using QuizChallenge.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuizChallenge.Scripts.UI;
using QuizChallenge.Scripts.Extensions;

namespace QuizChallenge.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GridCreator _gridCreator;
        [SerializeField] private CellDataLoader _cellDataLoader;
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private TaskResolver _taskResolver;
        [SerializeField] private RestartPanel _restartPanel;
        [SerializeField] private LoadPanel _loadPanel;
        [SerializeField] private ClickHandler _clickHandler;
        [SerializeField] private float _durationLoadLevel = 2f;

        private byte _currentLevel = 0;

        private void Start()
        {
            LoadNextLevel(true);

            _taskResolver.TaskResolved += OnTaskResolved;
        }

        private void OnDestroy()
        {
            _taskResolver.TaskResolved -= OnTaskResolved;
        }

        private void OnTaskResolved()
        {
            _clickHandler.DisableClick();

            _currentLevel++;
            this.InvokeMethodAfterDelay(() => LoadNextLevel(), _durationLoadLevel);
        }

        public void LoadNextLevel(bool isFirstLaunch = false)
        {
            if (_levelConfig.TryGetLevelData(_currentLevel, out LevelData levelData))
            {
                List<Cell> cellsGenerated = _gridCreator.Generate(levelData, isFirstLaunch);
                Cell TaskCell = _cellDataLoader.GetTaskCellLoadData(cellsGenerated, levelData.DataSets);
                _taskResolver.SetListCells(cellsGenerated, TaskCell);

                if (isFirstLaunch)
                {
                    _clickHandler.DisableClick();
                    _loadPanel.StartHide();
                }
                else
                {
                    _clickHandler.EnableClick();
                }
            }
            else
            {
                _restartPanel.StartShow();
            }
        }
    }
}
