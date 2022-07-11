using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Elements.Game
{
    [RequireComponent(typeof(Button))]
    public class BoneSelectorButton : MonoBehaviour
    {
        private Button _button;

        public event Action OnClicked;
        
        public void SetColor(Color color)
        {
            _button.image.color = color;
        }

        private void Click()
        {
            OnClicked?.Invoke();
        }
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }
    }
}