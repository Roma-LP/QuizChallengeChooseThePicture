using QuizChallenge.Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuizChallenge.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private RestartPanel _restartPanel;
        [SerializeField] private LoadPanel _loadPanel;

        private bool _isLoadPanelShowed = false;

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

        //public void OnRestartClicked()
        //{
        //    _loadPanel.StartShow();
        //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        //}

        public void OnLoadPanelShowed()
        {
            _isLoadPanelShowed = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        // Метод для загрузки сцены асинхронно
        public void OnRestartClicked()
        {
            _loadPanel.StartShow();
            //StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
        }

        // Корутина для загрузки сцены и ожидания ее завершения
        private IEnumerator LoadSceneCoroutine(int buildIndex)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);
            asyncOperation.allowSceneActivation = false;

            yield return asyncOperation;
            Debug.Log("сцена загрузилась");
            yield return new WaitUntil(() => _isLoadPanelShowed);
            Debug.Log("_isLoadPanelShowed true");
            asyncOperation.allowSceneActivation = true;
        }
    }
}
