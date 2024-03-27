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

        List<Cell> _cells;

        public void ShowCell()
        {
            StartCoroutine(AnimateElements());

            IEnumerator AnimateElements()
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    _cells[i].transform.localScale = Vector3.zero;
                    _cells[i].gameObject.SetActive(true);
                    _cells[i].transform.DOScale(1f, _duration).SetEase(Ease.InBounce);

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
