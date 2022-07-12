using System;
using System.Threading.Tasks;
using Sources.Model.Attack;
using Sources.Model.Bodies;
using Sources.Model.Defence;
using Sources.Model.Heal;
using Sources.Model.Players.ReadyControl;
using Sources.Model.Players.ReadyControl.Choose;

namespace Sources.Model.Players
{
    public abstract class BasePlayer
    {
        protected readonly BodyPartTypeGenerator BodyPartTypeGenerator;

        private readonly Health _health;

        public IReadOnlyHealth Health => _health;

        public Defender Defender { get; }

        public Attacker Attacker { get; }

        public Readiness Readiness { get; }

        public DamageTaker DamageTaker { get; }

        public SelectorChain PartSelectorChain { get; }

        protected BasePlayer(Body body, int startHealth, int damage, int defenceCapacity)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            
            _health = new Health(startHealth);

            Attacker = new Attacker(body, 1, damage, this);
            Defender = new Defender(body, defenceCapacity, this);
            
            DamageTaker = new DamageTaker(this, _health);

            BodyPartTypeGenerator = new BodyPartTypeGenerator();

            PartSelectorChain = new SelectorChain(new BodyPartSelectorHandler(Attacker),
                new BodyPartSelectorHandler(Defender));
            Readiness = new Readiness(PartSelectorChain, Attacker, Defender);
        }

        public abstract Task<BodyPartType> ChooseDefense();

        public abstract Task<BodyPartType> ChooseAttack();
    }
}