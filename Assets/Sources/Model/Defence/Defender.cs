using System;
using System.Collections.Generic;

namespace Sources.Model.Bodies
{
    public class Defender : IReadOnlyDefender
    {
        private readonly Body _body;
        
        private readonly Stack<BodyPartType> _defenced = new Stack<BodyPartType>();

        public int DefencedPartsCount => _defenced.Count;

        public Defender(Body body)
        {
            _body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public float CalculateDamagePercentsOfPart(BodyPartType partType)
        {
            if (IsPartDefenced(partType))
                return 0;

            return _body.GetPartOfType(partType).DamagePercents;
        }
        
        public bool IsPartDefenced(BodyPartType partType) => _defenced.Contains(partType);
        
        public void DefencePart(BodyPartType partType)
        {
            if (_defenced.Contains(partType))
                throw new InvalidOperationException($"{partType.ToString()} is already defenced");
            
            _defenced.Push(partType);
        }
        
        public void ClearAllDefence()
        {
            _defenced.Clear();
        }
    }
}