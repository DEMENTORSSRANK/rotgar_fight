using System;
using System.Collections.Generic;
using Sources.Model.Bodies;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public class InputButtonsChooser : IReadOnlyInputButtonsChooser
    {
        private readonly ButtonsContainer _container;

        private readonly List<BoneSelectorButton> _selected = new List<BoneSelectorButton>();
        
        public event Action<BoneSelectorButton> AttackChosen;

        public event Action<BoneSelectorButton> AttackUnChosen; 
        
        public event Action<BoneSelectorButton> DefenseChosen;

        public event Action<BoneSelectorButton> DefenseUnChosen;

        public IEnumerable<BoneSelectorButton> Selected => _selected;

        public InputButtonsChooser(ButtonsContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        
        public void ChooseAttack(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetAttackButtonByType(partType);
            
            AttackChosen?.Invoke(button);
            
            _selected.Add(button);
        }

        public void UnChooseAttack(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetAttackButtonByType(partType);
            
            AttackUnChosen?.Invoke(button);
            
            _selected.Remove(button);
        }

        public void ChooseDefense(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetDefenseButtonByType(partType);
            
            DefenseChosen?.Invoke(button);
            
            _selected.Add(button);
        }

        public void UnChooseDefense(BodyPartType partType)
        {
            BoneSelectorButton button = _container.GetDefenseButtonByType(partType);
            
            DefenseUnChosen?.Invoke(button);

            _selected.Remove(button);
        }
    }
}