using System;
using Sources.Model.Players;
using Sources.Model.Time;

namespace Sources.Model.Parameters
{
    public class GameParameters : IGameParameters
    {
        public ITimer Timer { get; }
        
        public BasePlayer Player { get; }
        
        public BasePlayer Enemy { get; }

        public GameParameters(ITimer timer, BasePlayer player, BasePlayer enemy)
        {
            Timer = timer ?? throw new ArgumentNullException(nameof(timer));
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }
    }
}