using QuizChallenge.Scripts.Cells;
using QuizChallenge.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts
{
    public class TaskResolver : MonoBehaviour
    {
        [SerializeField] private TaskText _taskText;

        private List<Cell> _cells;
        private Cell _taskCell;

        public event Action TaskResolved;

        private void Subscribe()
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                _cells[i].CellClicked += OnCellClicked;
            }
        }

        private void UnSubscribe()
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                _cells[i].CellClicked -= OnCellClicked;
            }
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }


        private void OnCellClicked(Cell cellClicked)
        {
            if (cellClicked.SpritesGamePlay.TaskName == _taskCell.SpritesGamePlay.TaskName)
            {
                cellClicked.CellAnimations.CorrectClick();
                TaskResolved?.Invoke();
            }
            else
            {
                cellClicked.CellAnimations.WrongClick();
            }
        }

        public void SetListCells(List<Cell> cells, Cell taskCell)
        {
            _cells = cells;

            _taskCell = taskCell;
            _taskText.SetTask(_taskCell.SpritesGamePlay.TaskName);

            Subscribe();
        }
    }
}