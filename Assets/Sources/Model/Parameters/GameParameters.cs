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
        
        public float AttackDelay { get; }
        
        public float MoveDelay { get; }

        public GameParameters(ITimer timer, BasePlayer player, BasePlayer enemy, float attackDelay, float moveDelay)
        {
            if (attackDelay < 0)
                throw new ArgumentOutOfRangeException(nameof(attackDelay));
            
            if (moveDelay < 0)
                throw new ArgumentOutOfRangeException(nameof(moveDelay));

            AttackDelay = attackDelay;
            MoveDelay = moveDelay;
            Timer = timer ?? throw new ArgumentNullException(nameof(timer));
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }
    }
}