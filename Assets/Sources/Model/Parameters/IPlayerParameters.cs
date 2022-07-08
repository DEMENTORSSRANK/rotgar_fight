using System.Collections.Generic;
using Sources.Model.Bodies;

namespace Sources.Model.Parameters
{
    public interface IPlayerParameters
    {
        int StartHealth { get; }
        
        int Damage { get; }
        
        Dictionary<BodyPartType, int> BodyPartsDamagePercentsMap { get; }
    }
}