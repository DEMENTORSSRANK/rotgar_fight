using System;
using System.Linq;

namespace Sources.Model.Bodies
{
    public class BodyPartTypeGenerator
    {
        public static readonly BodyPartType[] ObligatoryPartTypes = (BodyPartType[]) Enum.GetValues(typeof(BodyPartType));

        public int Count => ObligatoryPartTypes.Length;

        private readonly Random _random = new Random();

        public BodyPartType GenerateRandom(params BodyPartType[] exception)
        {
            BodyPartType[] available = ObligatoryPartTypes.Where(x => !exception.Contains(x)).ToArray();

            int index = _random.Next(0, available.Length);

            return available[index];
        }

        public BodyPartType GenerateRandom()
        {
            int index = _random.Next(0, ObligatoryPartTypes.Length);

            return ObligatoryPartTypes[index];
        }
    }
}