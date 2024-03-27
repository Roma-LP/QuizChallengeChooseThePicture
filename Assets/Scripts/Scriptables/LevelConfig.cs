using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/SpawnLevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levelDatas = new List<LevelData>();

        public bool TryGetLevelData(int levelNumber, out LevelData levelData)
        {
            if (levelNumber < _levelDatas.Count && levelNumber >= 0)
                levelData = _levelDatas[levelNumber];
            else
                levelData = null;

            return levelData != null;
        }
    }
}
