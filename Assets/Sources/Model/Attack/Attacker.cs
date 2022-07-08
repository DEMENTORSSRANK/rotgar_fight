using System;
using Sources.Model.Bodies;
using Sources.Model.Players;

namespace Sources.Model.Attack
{
    public class Attacker : IReadOnlyPlayerAttacker
    {
        // TODO: Abstract part containers
        public bool IsReady { get; set; }
        
        public int Damage { get; }

        public BodyPartType SelectedToAttack { get; private set; }
        
        public Attacker(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            Damage = damage;
        }

        public void SelectAttack(BodyPartType partType)
        {
            SelectedToAttack = partType;
            
            IsReady = true;
        }
        
        public void Attack(BasePlayer target)
        {
            target.GetAttack(SelectedToAttack, Damage);
        }
    }
}