using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuizChallenge.Scripts.UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private float _duration;
        [SerializeField, Range(0, 1)] private float _endValueFade;
        [SerializeField] private Image _backgroundPanel;

        public event Action RestartClicked;

        private void Awake()
        {
            SetActivePanelButtons(false);

            _restartButton.onClick.AddListener(ButtonClicked);
            SetButtonInteracteble(false);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            RestartClicked?.Invoke();
        }

        private void SetActivePanelButtons(bool activeMod)
        {
            _backgroundPanel.gameObject.SetActive(activeMod);
            _restartButton.gameObject.SetActive(activeMod);
        }

        private void SetButtonInteracteble(bool isInteract)
        {
            _restartButton.interactable = isInteract;
        }

        public void StartShow()
        {
            SetActivePanelButtons(true);

            _backgroundPanel.DOFade(_endValueFade, _duration).SetEase(Ease.Linear);
            _restartButton.image.DOFade(1, _duration).SetEase(Ease.Linear).OnComplete(() => SetButtonInteracteble(true));
        }
    }
}
