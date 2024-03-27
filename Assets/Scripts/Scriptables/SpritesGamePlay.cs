using UnityEngine;

namespace QuizChallenge.Scripts.Scriptables
{
    [System.Serializable]
    public class SpritesGamePlay
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _taskName;
        [SerializeField] private float _rotationZ;

        public Sprite Sprite => _sprite;
        public string TaskName => _taskName;
        public float RotationZ => _rotationZ;
    }
}
