using System;
using System.Linq;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public class InputButtonsView
    {
        private readonly ButtonsContainer _container;

        private readonly ButtonsViewParameters _parameters;

        public InputButtonsView(ButtonsContainer container, ButtonsViewParameters parameters)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void AllToDefault()
        {
            _container.AttackButtons.Select(x => x.Button).ToList().ForEach(ApplyToDefaultState);
            
            _container.DefenseButtons.Select(x => x.Button).ToList().ForEach(ApplyToDefaultState);
        }

        public void ApplyToChosenState(BoneSelectorButton button)
        {
            button.SetColor(_parameters.Chosen);
        }

        public void ApplyToDefaultState(BoneSelectorButton button)
        {
            button.SetColor(_parameters.Default);
        }
    }
}