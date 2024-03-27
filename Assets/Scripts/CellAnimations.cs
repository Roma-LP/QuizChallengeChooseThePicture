using DG.Tweening;
using QuizChallenge.Scripts.Cells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts
{
    public class CellAnimations : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private float _durationBetweenCells;
        [SerializeField] private ClickHandler _clickHandler;

        private List<Cell> _cells;
        private float _localeScale;

        public void ShowCell()
        {
            StartCoroutine(AnimateElements());

            IEnumerator AnimateElements()
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    _localeScale = _cells[i].transform.localScale.x;
                    _cells[i].transform.localScale = Vector3.zero;
                    _cells[i].gameObject.SetActive(true);
                    _cells[i].transform.DOScale(_localeScale, _duration).SetEase(Ease.InBounce);

                    yield return new WaitForSeconds(_durationBetweenCells);
                }

                _clickHandler.EnableClick();
            }
        }

        public void SetCells(List<Cell> cells)
        {
            _cells = cells;
        }
    }
}
