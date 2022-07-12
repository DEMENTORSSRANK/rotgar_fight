using System;
using System.Linq;
using Sources.Model.Bodies;

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

        public void ChooseAttack(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetAttackButtonByType(partType);
            
            ApplyToChosenState(button);
        }

        public void UnChooseAttack(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetAttackButtonByType(partType);
            
            ApplyToDefaultState(button);
        }

        public void ChooseDefense(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetDefenseButtonByType(partType);
            
            ApplyToChosenState(button);
        }

        public void UnChooseDefense(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetDefenseButtonByType(partType);
            
            ApplyToDefaultState(button);
        }

        public void AllToDefault()
        {
            _container.AttackButtons.Select(x => x.Button).ToList().ForEach(ApplyToDefaultState);
            
            _container.DefenseButtons.Select(x => x.Button).ToList().ForEach(ApplyToDefaultState);
        }

        private void ApplyToChosenState(BoneSelectorButton button)
        {
            button.SetColor(_parameters.Chosen);
        }

        private void ApplyToDefaultState(BoneSelectorButton button)
        {
            button.SetColor(_parameters.Default);
        }
    }
}