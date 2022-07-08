using System;
using Sources.Model.Bodies;

namespace Sources.Input
{
    public class PlayerInput
    {
        public event Action<BodyPartType> AttackChosen;
        
        public event Action<BodyPartType> DefenseChosen;

        public event Action GotReady;

        public void ChooseAttack(BodyPartType partType)
        {
            AttackChosen?.Invoke(partType);
        }

        public void ChooseDefense(BodyPartType partType)
        {
            DefenseChosen?.Invoke(partType);
        }

        public void CompleteChoose()
        {
            GotReady?.Invoke();
        }
    }
}