using System;
using System.Linq;

namespace Sources.Model.Bodies
{
    public class BodyPartTypeGenerator
    {
        private readonly BodyPartType[] _obligatoryPartTypes = (BodyPartType[]) Enum.GetValues(typeof(BodyPartType));

        public int Count => _obligatoryPartTypes.Length;

        private readonly Random _random = new Random();

        public BodyPartType GenerateRandom(params BodyPartType[] exception)
        {
            BodyPartType[] available = _obligatoryPartTypes.Where(x => !exception.Contains(x)).ToArray();

            int index = _random.Next(0, available.Length);

            return available[index];
        }

        public BodyPartType GenerateRandom()
        {
            int index = _random.Next(0, _obligatoryPartTypes.Length);

            return _obligatoryPartTypes[index];
        }
    }
}