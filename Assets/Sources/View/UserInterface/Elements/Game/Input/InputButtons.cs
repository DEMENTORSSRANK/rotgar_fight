using System;
using Sources.Input;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    [Serializable]
    public class InputButtons : MonoBehaviour
    {
        [SerializeField] private ButtonsContainer _container;

        [SerializeField] private ButtonsViewParameters _parameters;

        private InputButtonsSender _sender;

        public IPlayerInputSender Sender => _sender;

        public InputButtonsView View { get; private set; }

        public void Init()
        {
            _sender = new InputButtonsSender(_container);
            View = new InputButtonsView(_container, _parameters);
        }

        public void Start()
        {
            _sender.Subscribe();
            
            View.AllToDefault();
        }
    }
}