using Sources.Model.Players;
using Sources.Model.Time;

namespace Sources.Model.Parameters
{
    public interface IGameParameters
    {
        int AvailableDefencePartsCount { get; }

        int AvailableAttackPartsCount { get; }
        
        ITimer Timer { get; }
        
        BasePlayer Player { get; }
        
        BasePlayer Enemy { get; }
    }
}