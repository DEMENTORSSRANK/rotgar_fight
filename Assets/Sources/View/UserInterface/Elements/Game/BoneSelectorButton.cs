using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Elements.Game
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    public class BoneSelectorButton : MonoBehaviour
    {
        private Button _button;

        private Transform _followTarget;

        public event Action OnClicked;
        
        public RectTransform RectTransform { get; private set; }

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

            RectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }
    }
}