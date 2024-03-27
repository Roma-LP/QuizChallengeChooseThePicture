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
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private GameObject _backgroundSprite;

        private List<Cell> _cells = new List<Cell>();
        private GameObject _backgroundSpriteInstantiated;

        private void Clear()
        {
            for (int i = 0; i < _cells.Count;)
            {
                DestroyImmediate(_cells[i].gameObject);

                _cells.RemoveAt(i);
            }
        }

        public List<Cell> Generate(LevelData levelData, bool isFirstLaunch = false)
        {
            Clear();

            float gridWidth = levelData.Columns * (levelData.CellWidth + levelData.Spacing) - levelData.Spacing + levelData.BorderWidth * 2;//borderWidth
            float gridHeight = levelData.Rows * (levelData.CellHeight + levelData.Spacing) - levelData.Spacing + levelData.BorderWidth * 2;

            if(_backgroundSpriteInstantiated == null)
                _backgroundSpriteInstantiated = Instantiate(_backgroundSprite, transform.position, Quaternion.identity);
            _backgroundSpriteInstantiated.transform.localScale = new Vector3(gridWidth, gridHeight, 1);
            _backgroundSpriteInstantiated.transform.parent = _container;

            float startX = -(gridWidth / 2) + (levelData.CellWidth / 2) + levelData.BorderWidth;//borderWidth
            float startY = gridHeight / 2 - (levelData.CellHeight / 2) - levelData.BorderWidth; //borderWidth

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
    }
}
