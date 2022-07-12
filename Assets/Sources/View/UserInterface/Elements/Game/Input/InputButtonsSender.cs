using System;
using Sources.Input;
using Sources.Model.Bodies;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public class InputButtonsSender : IPlayerInputSender
    {
        private readonly ButtonsContainer _container;
        
        public event Action<BodyPartType> OnAttackChosen;
        
        public event Action<BodyPartType> OnDefenseChosen;
        
        public event Action OnGetReady;

        public InputButtonsSender(ButtonsContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        
        private void AttackChoose(BodyPartType partType)
        {
            OnAttackChosen?.Invoke(partType);
        }

        private void DefenseChoose(BodyPartType partType)
        {
            OnDefenseChosen?.Invoke(partType);
        }

        private void ReadyClicked()
        {
            OnGetReady?.Invoke();
        }

        public void Subscribe()
        {
            foreach (var attackPartTypedButton in _container.AttackButtons)
            {
                attackPartTypedButton.Button.OnClicked += delegate
                {
                    AttackChoose(attackPartTypedButton.PartType);
                };
            }

            foreach (var defensePartTypedButton in _container.DefenseButtons)
            {
                defensePartTypedButton.Button.OnClicked += delegate
                {
                    DefenseChoose(defensePartTypedButton.PartType);
                };
            }

            _container.Ready.onClick.AddListener(ReadyClicked);
        }
    }
}