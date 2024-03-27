using QuizChallenge.Scripts.Scriptables;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuizChallenge.Scripts.Cells
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _cellItem;
        [SerializeField] private Vector2Int _position;
        [SerializeField] private float _cellWidth;
        [SerializeField] private float _cellHeight;
        [SerializeField] private PictureAnimations _cellAnimations;

        private byte _numberCell;
        private SpritesGamePlay _spritesGamePlay;

        public SpriteRenderer CellItem => _cellItem;
        public SpritesGamePlay SpritesGamePlay => _spritesGamePlay;
        public PictureAnimations CellAnimations => _cellAnimations;

        public event Action<Cell> CellClicked;

        public void Init(byte numberCell, float cellWidth, float cellHeight, Vector2Int position, float scale)
        {
            _numberCell = numberCell;
            _position = position;
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            // _spritesGamePlay = spritesGamePlay;
            _cellItem.transform.localScale = new Vector3(scale, scale, scale);


            transform.localScale = new Vector3(_cellWidth, _cellHeight, 1);
            name = $"X: {_position.x}, Y:{_position.y}";
        }

        public void SetDataCell(SpritesGamePlay spritesGamePlay)
        {
            _spritesGamePlay = spritesGamePlay;

            _cellItem.sprite = _spritesGamePlay.Sprite;
            _cellItem.transform.localEulerAngles = new Vector3(_cellItem.transform.localEulerAngles.x, _cellItem.transform.localEulerAngles.y, _spritesGamePlay.RotationZ);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CellClicked?.Invoke(this);
        }
    }
}
