using TMPro;
using UnityEngine;

namespace QuizChallenge.Scripts.UI
{
    public class TaskText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _initialPhraseTask = "Find: ";

        public void SetTask(string task)
        {
            _text.text = $"{_initialPhraseTask}{task}";
        }
    }
}