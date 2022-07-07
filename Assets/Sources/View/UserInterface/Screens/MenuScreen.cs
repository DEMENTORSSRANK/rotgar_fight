using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _arena;

        [SerializeField] private Button _character;

        [SerializeField] private Button _exit;

        private void OnArenaClicked()
        {
            
        }

        private void OnCharacterClicked()
        {
            
        }

        private void OnExitClicked()
        {
            Application.Quit();
        }

        private void Start()
        {
            _arena.onClick.AddListener(OnArenaClicked);
            
            _character.onClick.AddListener(OnCharacterClicked);
            
            _exit.onClick.AddListener(OnExitClicked);
        }
    }
}