using QuizChallenge.Scripts.UI;
using UnityEngine;


namespace QuizChallenge.Scripts
{
    public class LaunchAnimations : MonoBehaviour
    {
        [SerializeField] private LoadPanel _loadPanel;
        [SerializeField] private CellAnimations _cellAnimations;
        [SerializeField] private TaskTextAnimations _taskTextAnimations;

        private void Awake()
        {
            _loadPanel.LoadPanelHided += OnLoadPanelHided;
        }

        private void OnDestroy()
        {
            _loadPanel.LoadPanelHided -= OnLoadPanelHided;
        }
        private void OnLoadPanelHided()
        {
            _cellAnimations.ShowCell();
            _taskTextAnimations.StartShow();
        }
    }
}
