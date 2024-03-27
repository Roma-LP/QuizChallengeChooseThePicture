using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuizChallenge.Scripts.UI
{
    public class LoadPanel : MonoBehaviour
    {
        [SerializeField] private Image _backgroundPanel;
        [SerializeField] private float _duration = 1f;

        public event Action LoadPanelHided;
        public event Action LoadPanelShowed;

        private void Fade(bool selfActive, float value, float duration, Action callback)
        {
            _backgroundPanel.gameObject.SetActive(selfActive);

            _backgroundPanel.DOFade(value, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                callback?.Invoke();
            });
        }

        public void StartShow()
        {          
            Fade(true, 1, _duration, () => LoadPanelShowed?.Invoke());
        }

        public void StartHide()
        {
            Fade(true, 0, _duration, () =>
            {
                _backgroundPanel.gameObject.SetActive(false);
                LoadPanelHided?.Invoke();
            });
        }
    }
}
