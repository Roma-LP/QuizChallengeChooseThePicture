using QuizChallenge.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizChallenge.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private RestartPanel _restartPanel;
        [SerializeField] private LoadPanel _loadPanel;

        private void Awake()
        {
            _restartPanel.RestartClicked += OnRestartClicked;
            _loadPanel.LoadPanelShowed += OnLoadPanelShowed;
        }

        private void OnDestroy()
        {
            _restartPanel.RestartClicked -= OnRestartClicked;
            _loadPanel.LoadPanelShowed -= OnLoadPanelShowed;
        }

        public void OnLoadPanelShowed()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnRestartClicked()
        {
            _loadPanel.StartShow();
        }
    }
}
