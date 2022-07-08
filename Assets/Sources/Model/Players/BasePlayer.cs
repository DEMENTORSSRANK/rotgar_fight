using System;
using System.Linq;
using System.Threading.Tasks;
using Sources.Model.Attack;
using Sources.Model.Bodies;
using Sources.Model.Defence;
using Sources.Model.Heal;
using UnityEngine;

namespace Sources.Model.Players
{
    public abstract class BasePlayer
    {
        private readonly Body _body;

        protected readonly BodyPartTypeGenerator BodyPartTypeGenerator;

        protected bool AvailableToReady => Defender.IsReady && Attacker.IsReady;
        
        public bool IsReady { get; private set; }
        
        public bool IsChoosingDefense { get; private set; }

        public bool IsChoosingAttack { get; private set; }

        public Health Health { get; }

        public Defender Defender { get; }

        public Attacker Attacker { get; }

        protected BasePlayer(Body body, int startHealth, int damage, int defenceCapacity)
        {
            _body = body ?? throw new ArgumentNullException(nameof(body));
            Health = new Health(startHealth);
            Attacker = new Attacker(damage);
            Defender = new Defender(_body, defenceCapacity);
            BodyPartTypeGenerator = new BodyPartTypeGenerator();
        }

        public async void ChoosingDefenseAsync()
        {
            if (IsChoosingDefense)
                throw new InvalidOperationException("Already choosing");
            
            Defender.ClearAllDefence();

            IsChoosingDefense = true;
            
            while (IsChoosingDefense)
            {
                BodyPartType chosen = await ChooseDefense();

                if (!IsChoosingDefense)
                    break;

                Debug.Log($"Defence {GetType()} choose: {chosen}");
                
                Defender.DefencePart(chosen);
            }
        }

        public async void ChoosingAttackAsync()
        {
            if (IsChoosingAttack)
                throw new InvalidOperationException("Already choosing");
            
            Attacker.IsReady = false;

            IsChoosingAttack = true;
            
            while (IsChoosingAttack)
            {
                BodyPartType chosen = await ChooseAttack();

                if (!IsChoosingAttack)
                    break;

                Attacker.SelectAttack(chosen);
            }
        }

        public void StopAllChoosing()
        {
            IsChoosingAttack = false;

            IsChoosingDefense = false;
        }

        public void PushToReady()
        {
            if (IsReady)
                throw new InvalidOperationException("Already ready");

            if (AvailableToReady)
            {
                MakeReady();
                
                return;
            }

            PushRandomDefense();
            
            PushRandomAttack();
            
            MakeReady();
        }
        
        public void PushRandomDefense()
        {
            while (!Defender.IsReady)
            {
                Defender.DefencePart(BodyPartTypeGenerator.GenerateRandom(Defender.Defenced.ToArray()));
            }
        }

        public void PushRandomAttack()
        {
            if (Attacker.IsReady)
                return;
            
            Attacker.SelectAttack(BodyPartTypeGenerator.GenerateRandom());
        }

        public void MakeReady()
        {
            if (!IsChoosingAttack || !IsChoosingDefense)
                throw new InvalidOperationException("Not choosing yet");
            
            if (!AvailableToReady)
                throw new InvalidOperationException("Not available to ready");
            
            if (IsReady)
                throw new InvalidOperationException("Already ready");

            IsReady = true;
            
            StopAllChoosing();
        }

        public void UnReady()
        {
            IsReady = false;
        }

        public void GetAttack(BodyPartType partType, int damage)
        {
            float resultDamage = damage * Defender.CalculateDamageModifierOfPart(partType);

            Debug.Log($"{GetType()} got damaged on {partType}: {resultDamage}");
            
            Health.ApplyDamage(resultDamage);
        }
        
        protected abstract Task<BodyPartType> ChooseDefense();

        protected abstract Task<BodyPartType> ChooseAttack();
    }
}