using Sources.Model.Players;

namespace Sources.Model.Parameters
{
    public interface IGameParameters
    {
        int AvailableDefencePartsCount { get; }

        int AvailableAttackPartsCount { get; }
        
        int MoveSeconds { get; }
        
        BasePlayer Player { get; }
        
        BasePlayer Enemy { get; }
    }
}