using System;
using Sources.Model.Bodies;
using Sources.Model.Heal;
using Sources.Model.Players;

namespace Sources.Model.Defence
{
    public class DamageTaker
    {
        private readonly BasePlayer _player;

        private readonly Health _health;

        public event Action Blocked;

        public event Action<BodyPartType> Hit; 

        public DamageTaker(BasePlayer player, Health health)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public void TakeAttack(BodyPartType partType, int damage, out float resultDamage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            resultDamage = damage * _player.Defender.CalculateDamageModifierOfPart(partType);

            if (Math.Abs(resultDamage) < .1f)
            {
                Blocked?.Invoke();

                return;
            }
            
            Hit?.Invoke(partType);

            _health.ApplyDamage(resultDamage);
        }

        public float CalculatePrevResultDamage(BodyPartType partType, int damage)
        {
            return damage * _player.Defender.CalculateDamageModiferWithoutBlock(partType);
        }
    }
}