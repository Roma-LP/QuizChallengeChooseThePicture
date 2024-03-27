using DG.Tweening;
using UnityEngine;

namespace QuizChallenge.Scripts.Cells
{
    public class PictureAnimations : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private Vector3 _strengthShake;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private ParticleSystem _particleSystem;

        private Tween _tween;
        private Sequence sequence;

        public void WrongClick()
        {
            if (_tween != null)
                return;

            _tween = _spriteRenderer.transform.DOShakePosition(_duration, _strengthShake).OnComplete(() =>
            {
                _tween = null;
            });
        }

        public void CorrectClick()
        {
            if (sequence != null)
                return;

            _particleSystem.Play();

            Vector3 start = _spriteRenderer.transform.localScale;
            sequence = DOTween.Sequence();
            sequence.Append(_spriteRenderer.transform.DOScale(_scale, _duration).SetEase(Ease.InBounce));
            sequence.Append(_spriteRenderer.transform.DOScale(start, _duration).SetEase(Ease.Linear));
            sequence.AppendCallback(() =>
            {
                sequence = null;
            });
        }
    }
}
