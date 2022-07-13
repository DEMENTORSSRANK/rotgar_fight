using System;
using System.Linq;
using System.Threading.Tasks;
using Sources.Model.Bodies;
using Sources.Model.Players;
using Sources.Model.Players.ReadyControl.Choose;

namespace Sources.Model.Attack
{
    public class Attacker : BodyPartSelector
    {
        private readonly BasePlayer _player;

        public int Damage { get; }

        public event Action<BodyPartType> Attacked;

        public event Action<BodyPartType, float> AttackedWithDamage; 

        public Attacker(Body body, int capacity, int damage, BasePlayer player) : base(body, capacity)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _player = player ?? throw new ArgumentNullException(nameof(player));
            Damage = damage;
        }

        public void Attack(BasePlayer target)
        {
            BodyPartType targetPart = Chosen.Last();
            
            target.DamageTaker.TakeAttack(targetPart, Damage, out var resultDamage);

            Attacked?.Invoke(targetPart);
            
            AttackedWithDamage?.Invoke(targetPart, resultDamage);
        }

        public override Task<BodyPartType> ChoosePart() => _player.ChooseAttack();
    }
}