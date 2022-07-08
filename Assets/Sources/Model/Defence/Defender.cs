using System;
using System.Collections.Generic;
using Sources.Model.Bodies;

namespace Sources.Model.Defence
{
    public class Defender : IReadOnlyDefender
    {
        private readonly Body _body;

        private readonly int _capacity;

        private readonly Queue<BodyPartType> _defenced = new Queue<BodyPartType>();

        public int DefencedPartsCount => _defenced.Count;

        public bool IsReady => DefencedPartsCount >= _capacity;

        public IEnumerable<BodyPartType> Defenced => _defenced;

        public Defender(Body body, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            
            _body = body ?? throw new ArgumentNullException(nameof(body));
            _capacity = capacity;
        }

        public float CalculateDamageModifierOfPart(BodyPartType partType) => IsPartDefenced(partType)
            ? 0
            : _body.GetPartOfType(partType).DamagePercents / (float) 100;

        public bool IsPartDefenced(BodyPartType partType) => _defenced.Contains(partType);

        public void DefencePart(BodyPartType partType)
        {
            if (_defenced.Contains(partType))
                throw new InvalidOperationException($"{partType.ToString()} is already defenced");

            _defenced.Enqueue(partType);

            if (_defenced.Count > _capacity)
                _defenced.Dequeue();
        }

        public void ClearAllDefence()
        {
            _defenced.Clear();
        }
    }
}