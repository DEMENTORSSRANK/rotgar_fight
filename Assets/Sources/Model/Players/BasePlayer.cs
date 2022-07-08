using System;
using System.Threading.Tasks;
using Sources.Model.Attack;
using Sources.Model.Bodies;
using Sources.Model.Heal;

namespace Sources.Model.Players
{
    public abstract class BasePlayer
    {
        private readonly Body _body;

        public Health Health { get; }

        public Defender Defender { get; }

        public Attacker Attacker { get; }

        protected BasePlayer(Body body, int startHealth, int damage)
        {
            _body = body ?? throw new ArgumentNullException(nameof(body));
            Health = new Health(startHealth);
            Attacker = new Attacker(damage);
            Defender = new Defender(_body);
        }

        public abstract Task<BodyPartType> ChooseDefense();
        
        public abstract Task<BodyPartType> ChooseAttack();

        public void PushRandomDefense()
        {
            
        }

        public void PushRandomAttack()
        {
            
        }
    }
}