using System;
using System.Threading.Tasks;
using Sources.Model.Parameters;

namespace Sources.Model.GameScenario
{
    public abstract class BaseGameScenario
    {
        protected readonly IGameParameters GameParameters;
        
        public bool IsCompleting { get; private set; }

        /// <summary>
        /// True - win, False - lose
        /// </summary>
        public event Action<bool> GameEnd;

        protected BaseGameScenario(IGameParameters gameParameters)
        {
            GameParameters = gameParameters ?? throw new ArgumentNullException(nameof(gameParameters));
        }

        public async void StartAsync()
        {
            if (IsCompleting)
                throw new InvalidOperationException("Scenario is already completing now");

            IsCompleting = true;
            
            await GameCompletingAsync();

            IsCompleting = false;
            
            GameEnd?.Invoke(IsPlayerWin);
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