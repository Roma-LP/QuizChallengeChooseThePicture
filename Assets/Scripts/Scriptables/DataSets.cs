using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "DataSets", menuName = "ScriptableObjects/SpawnDataSets", order = 2)]
    public class DataSets : ScriptableObject
    {
        [SerializeField] private float _scaleSprites = 0.3f;
        [SerializeField] private string _identifier;
        [SerializeField] private List<SpritesGamePlay> _spritesGamePlay = new List<SpritesGamePlay>();

        public float ScaleSprites => _scaleSprites;
        public string Identifier => _identifier;

        public List<SpritesGamePlay> SpritesGamePlay => _spritesGamePlay;
    }
}
