using System;
using System.Linq;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public class InputButtonsActivator
    {
        private readonly ButtonsContainer _container;

        private readonly IReadOnlyInputButtonsChooser _chooser;

        public InputButtonsActivator(ButtonsContainer container, IReadOnlyInputButtonsChooser chooser)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _chooser = chooser ?? throw new ArgumentNullException(nameof(chooser));
        }

        public void UpdateAvailableIsReady(bool isReady)
        {
            _container.Ready.gameObject.SetActive(isReady);
        }
        
        public void OnStartChoosing()
        {
            ActiveAll();
            
            UpdateAvailableIsReady(false);
            
            EnableInteractable();
        }

        public void OnEndChoosing()
        {
            foreach (var button in _container.AttackButtons.Select(x => x.Button).Except(_chooser.Selected))
            {
                button.gameObject.SetActive(false);
            }
            
            foreach (var button in _container.DefenseButtons.Select(x => x.Button).Except(_chooser.Selected))
            {
                button.gameObject.SetActive(false);
            }
            
            DisableInteractable();
        }

        public void ActiveAll()
        {
            foreach (var attackButton in _container.AttackButtons)
            {
                attackButton.Button.gameObject.SetActive(true);
            }
            
            foreach (var defenseButton in _container.DefenseButtons)
            {
                defenseButton.Button.gameObject.SetActive(true);
            }
            
            _container.Ready.gameObject.SetActive(true);
        }
        
        public void InActiveAll()
        {
            foreach (var attackButton in _container.AttackButtons)
            {
                attackButton.Button.gameObject.SetActive(false);
            }
            
            foreach (var defenseButton in _container.DefenseButtons)
            {
                defenseButton.Button.gameObject.SetActive(false);
            }
            
            _container.Ready.gameObject.SetActive(false);
        }

        private void DisableInteractable()
        {
            foreach (var attackButton in _container.AttackButtons)
            {
                attackButton.Button.SetInteractable(false);
            }

            foreach (var defenseButton in _container.DefenseButtons)
            {
                defenseButton.Button.SetInteractable(false);
            }
        }

        private void EnableInteractable()
        {
            foreach (var attackButton in _container.AttackButtons)
            {
                attackButton.Button.SetInteractable(true);
            }

            foreach (var defenseButton in _container.DefenseButtons)
            {
                defenseButton.Button.SetInteractable(true);
            }
        }
    }
}