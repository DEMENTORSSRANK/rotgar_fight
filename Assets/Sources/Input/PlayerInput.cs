using System;
using Sources.Model.Bodies;

namespace Sources.Input
{
    public class PlayerInput
    {
        public event Action<BodyPartType> AttackChoosen;
        
        public event Action<BodyPartType> DefenseChoosen;

        public void ChooseAttack(BodyPartType partType)
        {
            AttackChoosen?.Invoke(partType);
        }

        public void ChooseDefense(BodyPartType partType)
        {
            DefenseChoosen?.Invoke(partType);
        }
    }
}