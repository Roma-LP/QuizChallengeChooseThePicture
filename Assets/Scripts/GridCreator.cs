using QuizChallenge.Scripts.Scriptables;
using QuizChallenge.Scripts.Cells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts
{
    public class GridCreator : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Cell cellPrefab; // Префаб ячейки
        [SerializeField] private GameObject backgroundPrefab; // Префаб фона с рамкой

        [SerializeField] private List<Cell> _cells = new List<Cell>();

        public List<Cell> Generate(LevelData levelData, bool isFirstLaunch = false)
        {
            Clear();

            // Рассчитываем размеры фона с рамкой
            float gridWidth = levelData.Columns * (levelData.CellWidth + levelData.Spacing) - levelData.Spacing + levelData.Spacing * 2;//borderWidth
            float gridHeight = levelData.Rows * (levelData.CellHeight + levelData.Spacing) - levelData.Spacing + levelData.Spacing * 2;

            // Создаем фон с рамкой
            GameObject background = Instantiate(backgroundPrefab, transform.position, Quaternion.identity);
            background.transform.localScale = new Vector3(gridWidth, gridHeight, 1);
            background.transform.parent = _container;

            // Рассчитываем положение левого верхнего угла сетки
            float startX = -(gridWidth / 2) + (levelData.CellWidth / 2) + levelData.Spacing;//borderWidth
            float startY = gridHeight / 2 - (levelData.CellHeight / 2) - levelData.Spacing; //borderWidth

            // Создаем ячейки
            for (int row = 0; row < levelData.Rows; row++)
            {
                for (int col = 0; col < levelData.Columns; col++)
                {
                    float x = startX + col * (levelData.CellWidth + levelData.Spacing);
                    float y = startY - row * (levelData.CellHeight + levelData.Spacing);

                    Cell cell = Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
                    cell.Init((byte)(_cells.Count - 1), levelData.CellWidth, levelData.CellHeight, new Vector2Int(row, col), levelData.DataSets.ScaleSprites);
                    cell.transform.parent = _container;
                    _cells.Add(cell);

                    if (isFirstLaunch)
                        cell.gameObject.SetActive(false);
                }
            }

            return _cells;
        }

        private void Clear()
        {
            for (int i = 0; i < _cells.Count;)
            {
                DestroyImmediate(_cells[i].gameObject);

                _cells.RemoveAt(i);
            }
        }
    }
}
