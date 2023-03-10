using System;
using System.Threading.Tasks;
using Sources.Extensions;
using Sources.Model.Parameters;

namespace Sources.Model.GameScenario
{
    public class LocalGameScenario : BaseGameScenario
    {
        public override event Action RoundStarted;
        
        public LocalGameScenario(IGameParameters gameParameters) : base(gameParameters)
        {
            
        }

        protected override async Task ProcessMoveAsync()
        {
            await Task.Delay(100);

            GameParameters.Timer.Launch();
            
            Player.PartSelectorChain.StartAllChoosing();
            Enemy.PartSelectorChain.StartAllChoosing();

            while (GameParameters.Timer.Running && (!Enemy.Readiness.IsReady || !Player.Readiness.IsReady))
                await Task.Delay(1);

            if (GameParameters.Timer.Running)
                GameParameters.Timer.Stop();
            
            if (!Enemy.Readiness.IsReady)
                Enemy.Readiness.PushToReady();
            
            if (!Player.Readiness.IsReady)
                Player.Readiness.PushToReady();
            
            RoundStarted?.Invoke();
            
            Player.Attacker.Attack(Enemy);

            if (Enemy.Health.IsDead)
            {
                StopAllGame();
                
                return;
            }

            await Task.Delay(GameParameters.AttackDelay.ToMilliseconds());

            Enemy.Attacker.Attack(Player);

            await Task.Delay(GameParameters.AttackDelay.ToMilliseconds());
            
            StopAllGame();
            
            await Task.Delay(GameParameters.MoveDelay.ToMilliseconds());
        }

        private void StopAllGame()
        {
            Player.Readiness.UnReady();
            
            Enemy.Readiness.UnReady();
        }
    }
}