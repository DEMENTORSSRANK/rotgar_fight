using System;
using System.Linq;

namespace Sources.Model.Bodies
{
    public class Body
    {
        private readonly BodyPart[] _parts;

        public Body(params BodyPart[] parts)
        {
            _parts = parts ?? throw new ArgumentNullException(nameof(parts));
        }

        public BodyPart GetPartOfType(BodyPartType partType) => _parts.First(x => x.Type == partType);
    }
}