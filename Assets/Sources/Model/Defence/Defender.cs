using System;
using System.Threading.Tasks;
using Sources.Model.Bodies;
using Sources.Model.Players;
using Sources.Model.Players.ReadyControl.Choose;
using UnityEngine;

namespace Sources.Model.Defence
{
    public class Defender : BodyPartSelector
    {
        private readonly BasePlayer _player;
        
        public Defender(Body body, int capacity, BasePlayer player) : base(body, capacity)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public float CalculateDamageModifierOfPart(BodyPartType partType) => Contains(partType)
            ? 0
            : Body.GetPartOfType(partType).DamagePercents / (float) 100;

        public override Task<BodyPartType> ChoosePart()
        {
            return _player.ChooseDefense();
        }
    }
}