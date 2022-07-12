using Sources.Model.Players;
using Sources.Model.Time;

namespace Sources.Model.Parameters
{
    public interface IGameParameters
    {
        ITimer Timer { get; }
        
        BasePlayer Player { get; }
        
        BasePlayer Enemy { get; }
        
        float AttackDelay { get; }
        
        float MoveDelay { get; }
    }
}