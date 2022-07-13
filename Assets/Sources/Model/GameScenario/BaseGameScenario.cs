using System;
using System.Threading.Tasks;
using Sources.Model.Parameters;
using Sources.Model.Players;

namespace Sources.Model.GameScenario
{
    public abstract class BaseGameScenario
    {
        protected readonly IGameParameters GameParameters;

        protected BasePlayer Player => GameParameters.Player;

        protected BasePlayer Enemy => GameParameters.Enemy;
        
        public bool IsCompleting { get; private set; }

        public event Action GameStarted;
        
        public event Action GameEnd;

        public event Action Defeat;

        public event Action Won;

        public abstract event Action RoundStarted;

        protected BaseGameScenario(IGameParameters gameParameters)
        {
            GameParameters = gameParameters ?? throw new ArgumentNullException(nameof(gameParameters));
        }

        public async void StartAsync()
        {
            if (IsCompleting)
                throw new InvalidOperationException("Scenario is already completing now");

            GameParameters.Player.Health.ResetToStartValue();
            
            GameParameters.Enemy.Health.ResetToStartValue();
            
            IsCompleting = true;
            
            GameStarted?.Invoke();
            
            await GameCompletingAsync();

            IsCompleting = false;

            Action action = IsPlayerWin ? Won : Defeat;
            
            action?.Invoke();
            
            GameEnd?.Invoke();
        }

        private async Task GameCompletingAsync()
        {
            while (!IsAnyWin())
            {
                await ProcessMoveAsync();
            }
        }

        protected abstract Task ProcessMoveAsync();

        private bool IsAnyWin() => GameParameters.Player.Health.IsDead || GameParameters.Enemy.Health.IsDead;

        private bool IsPlayerWin => GameParameters.Enemy.Health.IsDead;
    }
}