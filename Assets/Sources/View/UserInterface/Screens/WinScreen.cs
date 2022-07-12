using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Screens
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        [SerializeField] private Button _menu;
        
        public event Action RestartClicked;
        
        private void OnRestartClicked()
        {
            RestartClicked?.Invoke();
        }

        private void OnMenuClicked()
        {
            SceneManager.LoadScene("menu");
        }

        private void Start()
        {
            _restart.onClick.AddListener(OnRestartClicked);
            
            _menu.onClick.AddListener(OnMenuClicked);
        }
    }
}