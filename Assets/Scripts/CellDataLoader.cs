using QuizChallenge.Scripts.Cells;
using QuizChallenge.Scripts.Scriptables;
using QuizChallenge.Scripts.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts
{
    public class CellDataLoader : MonoBehaviour
    {
        [SerializeField] private List<SpritesGamePlay> _availableSpritesGamePlays; // delete ------------------------------------------------
        [SerializeField] private CellAnimations _cellAnimations;

        private List<SpritesGamePlay> _usedSpritesGamePlay;
        private AvailableSpritesData _availableSpritesData;

        public Cell GetTaskCellLoadData(List<Cell> cells, DataSets dataSets)
        {
            if (_availableSpritesData == null)
                _availableSpritesData = new AvailableSpritesData();

            _availableSpritesData.LoadDataSet(dataSets);

            DataSets currentDS = _availableSpritesData.GetDataSet(dataSets.Identifier);

            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].SetDataCell(GetUniqueSpritesGamePlay(currentDS));
            }

            Cell TaskCell = cells.GetRandomItem();
            _availableSpritesData.RemoveSpritesGamePlay(TaskCell.SpritesGamePlay, dataSets.Identifier);
            _usedSpritesGamePlay.Clear();

            //if (!cells.First().gameObject.activeSelf)
            //    _pictureAnimations.ShowCell(cells);
            _cellAnimations.SetCells(cells);

            return TaskCell;
        }

        private SpritesGamePlay GetUniqueSpritesGamePlay(DataSets dataSets)
        {
            SpritesGamePlay used;

            if (_usedSpritesGamePlay == null)
            {
                _usedSpritesGamePlay = new List<SpritesGamePlay>();

                used = dataSets.SpritesGamePlay.GetRandomItem();
                _usedSpritesGamePlay.Add(used);

                return used;
            }

            if (_usedSpritesGamePlay.Count == dataSets.SpritesGamePlay.Count)
            {
                _usedSpritesGamePlay.Clear();
            }

            while (true)
            {
                used = dataSets.SpritesGamePlay.GetRandomItem();
                if (_usedSpritesGamePlay.Contains(used))
                {
                    continue;
                }
                else
                {
                    _usedSpritesGamePlay.Add(used);
                    return used;
                }
            }
        }
    }
}