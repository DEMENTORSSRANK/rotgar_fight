using System;

namespace Sources.Model.Bodies
{
    public class BodyPart
    {
        public BodyPartType Type { get; }

        public int DamagePercents { get; }
        
        public BodyPart(BodyPartType type, int damagePercents)
        {
            if (damagePercents < 0)
                throw new ArgumentOutOfRangeException(nameof(damagePercents));
            
            Type = type;
            DamagePercents = damagePercents;
        }
    }
}