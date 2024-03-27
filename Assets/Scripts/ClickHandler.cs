using UnityEngine;
using UnityEngine.EventSystems;

namespace QuizChallenge.Scripts
{
    public class ClickHandler : MonoBehaviour
    {
        [SerializeField] private Physics2DRaycaster _physics2DRaycaster;

        public void DisableClick()
        {
            _physics2DRaycaster.enabled = false;
        }

        public void EnableClick()
        {
            _physics2DRaycaster.enabled = true;
        }
    }
}