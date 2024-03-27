using UnityEngine;

namespace QuizChallenge.Scripts.Scriptables
{
    [System.Serializable]
    public class LevelData
    {
        [SerializeField] private DataSets _dataSets;
        [SerializeField] private byte _rows = 1;
        [SerializeField] private byte _columns = 3;
        [SerializeField] private float _cellWidth = 1;
        [SerializeField] private float _cellHeight = 1;
        [SerializeField] private float _spacing = 0.1f;

        public byte Rows => _rows;
        public byte Columns => _columns;
        public float CellWidth => _cellWidth;
        public float CellHeight => _cellHeight;
        public float Spacing => _spacing;
        public DataSets DataSets => _dataSets;
    }
}
