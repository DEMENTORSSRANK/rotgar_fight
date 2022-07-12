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

        private InputButtonsView _view;

        public IPlayerInputSender Sender => _sender;

        public InputButtonsChooser Chooser { get; private set; }
        
        public InputButtonsActivator Activator { get; private set; }

        public void Init()
        {
            _sender = new InputButtonsSender(_container);
            Chooser = new InputButtonsChooser(_container);
            
            Activator = new InputButtonsActivator(_container, Chooser);
            _view = new InputButtonsView(_container, _parameters);

            Chooser.AttackChosen += _view.ApplyToChosenState;
            Chooser.DefenseChosen += _view.ApplyToChosenState;

            Chooser.AttackUnChosen += _view.ApplyToDefaultState;
            Chooser.DefenseUnChosen += _view.ApplyToDefaultState;
        }

        public void Start()
        {
            _sender.Subscribe();
            
            _view.AllToDefault();
            Activator.InActiveAll();
        }

        private void OnDisable()
        {
            Chooser.AttackChosen -= _view.ApplyToChosenState;
            Chooser.DefenseChosen -= _view.ApplyToChosenState;

            Chooser.AttackUnChosen -= _view.ApplyToDefaultState;
            Chooser.DefenseUnChosen -= _view.ApplyToDefaultState;
        }
    }
}