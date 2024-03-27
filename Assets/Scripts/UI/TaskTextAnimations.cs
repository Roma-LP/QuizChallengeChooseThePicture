using DG.Tweening;
using TMPro;
using UnityEngine;

namespace QuizChallenge.Scripts.UI
{
    public class TaskTextAnimations : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _duration = 0.3f;

        private void Awake()
        {
            _text.gameObject.SetActive(false);
        }

        public void StartShow()
        {
            _text.gameObject.SetActive(true);

            Color startColor = _text.color;
            startColor.a = 0f;
            _text.color = startColor;

            _text.DOFade(1, _duration).SetEase(Ease.Linear);
        }
    }
}