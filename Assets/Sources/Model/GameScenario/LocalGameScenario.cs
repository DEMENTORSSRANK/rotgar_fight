using System.Threading.Tasks;
using Sources.Model.Parameters;

namespace Sources.Model.GameScenario
{
    public class LocalGameScenario : BaseGameScenario
    {
        public LocalGameScenario(IGameParameters gameParameters) : base(gameParameters)
        {
            
        }
        
        protected override async Task ProcessMoveAsync()
        {
            GameParameters.Timer.Launch();
            
            Player.PartSelectorChain.StartAllChoosing();
            Enemy.PartSelectorChain.StartAllChoosing();

            while (GameParameters.Timer.Running && (!Enemy.Readiness.IsReady || !Player.Readiness.IsReady))
                await Task.Delay(1);
            
            if (!Enemy.Readiness.IsReady)
                Enemy.Readiness.PushToReady();
            
            if (!Player.Readiness.IsReady)
                Player.Readiness.PushToReady();
            
            Player.Attacker.Attack(Enemy);

            if (Enemy.Health.IsDead)
            {
                StopAllGame();
                
                return;
            }

            Enemy.Attacker.Attack(Player);

            StopAllGame();
        }

        private void StopAllGame()
        {
            Player.Readiness.UnReady();
            
            Enemy.Readiness.UnReady();

            if (GameParameters.Timer.Running)
                GameParameters.Timer.Stop();
        }
    }
}