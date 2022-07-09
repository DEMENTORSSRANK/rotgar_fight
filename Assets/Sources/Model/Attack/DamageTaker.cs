using System;
using Sources.Model.Bodies;
using Sources.Model.Heal;
using Sources.Model.Players;

namespace Sources.Model.Attack
{
    public class DamageTaker
    {
        private readonly BasePlayer _player;

        private readonly Health _health;

        public DamageTaker(BasePlayer player, Health health)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }
        
        public void TakeAttack(BodyPartType partType, int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            float resultDamage = damage * _player.Defender.CalculateDamageModifierOfPart(partType);

            _health.ApplyDamage(resultDamage);
        }
    }
}