using System;
using Sources.Model.Bodies;

namespace Sources.Model.Attack
{
    public class Attacker : IReadOnlyPlayerAttacker
    {
        public int Damage { get; }

        public BodyPartType SelectedToAttack { get; set; }
        
        public Attacker(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            Damage = damage;
        }
    }
}