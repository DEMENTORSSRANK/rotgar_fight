using System;
using System.Threading.Tasks;
using Sources.Model.Bodies;

namespace Sources.Model.Players
{
    public class LocalPlayer : BasePlayer
    {
        private BodyPartType _defense;

        private BodyPartType _attack;

        private bool _waitingDefense;

        private bool _waitingAttack;

        public LocalPlayer(Body body, int startHealth, int damage, int defenceCapacity) : base(body, startHealth,
            damage, defenceCapacity)
        {
        }

        public void InputDefense(BodyPartType partType)
        {
            if (!_waitingDefense)
                throw new InvalidOperationException("Cant input defense, not waiting");

            _defense = partType;

            _waitingDefense = false;
        }

        public void InputAttack(BodyPartType partType)
        {
            if (!_waitingAttack)
                throw new InvalidOperationException("Cant input attack, not waiting");

            _attack = partType;

            _waitingAttack = false;
        }

        public override async Task<BodyPartType> ChooseDefense()
        {
            _waitingDefense = true;

            while (_waitingDefense)
                await Task.Delay(1);

            return _defense;
        }

        public override async Task<BodyPartType> ChooseAttack()
        {
            _waitingAttack = true;

            while (_waitingAttack)
                await Task.Delay(1);

            return _attack;
        }
    }
}