using QuizChallenge.Scripts.Extensions;
using QuizChallenge.Scripts.Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace QuizChallenge.Scripts
{
    //[System.Serializable]
    public class AvailableSpritesData
    {
        private List<DataSets> _dataSets;

        public void LoadDataSet(DataSets dataSets)
        {
            if (_dataSets == null)
            {
                _dataSets = new List<DataSets>();
                DataSets clonedDS = dataSets.Clone();
                _dataSets.Add(clonedDS);
            }
            else
            {
                if (!_dataSets.Exists(x => x.Identifier == dataSets.Identifier))
                {
                    DataSets clonedDS = dataSets.Clone();
                    _dataSets.Add(clonedDS);
                }
            }
        }

        public DataSets GetDataSet(string identifierde)
        {
            return _dataSets.Find(x => x.Identifier == identifierde);
        }

        public void RemoveSpritesGamePlay(SpritesGamePlay spritesGamePlay, string identifierde)
        {
            //DataSets dataSets = _dataSets.Find(x => x.Identifier == identifierde);
            //dataSets.SpritesGamePlay.Remove(spritesGamePlay);

            _dataSets.Find(x => x.Identifier == identifierde).SpritesGamePlay.Remove(spritesGamePlay);
        }
    }
}