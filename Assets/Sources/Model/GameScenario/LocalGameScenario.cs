using System.Threading.Tasks;
using Sources.Model.Parameters;
using UnityEngine;

namespace Sources.Model.GameScenario
{
    public class LocalGameScenario : BaseGameScenario
    {
        public LocalGameScenario(IGameParameters gameParameters) : base(gameParameters)
        {
            
        }
        
        protected override async Task ProcessMoveAsync()
        {
            Debug.Log("Move started");
            
            GameParameters.Timer.Launch();
            
            Player.ChoosingAttackAsync();
            
            Player.ChoosingDefenseAsync();
            
            Enemy.ChoosingAttackAsync();
            
            Enemy.ChoosingDefenseAsync();
            
            while (GameParameters.Timer.Running && (!Enemy.IsReady || !Player.IsReady))
                await Task.Delay(1);
            
            if (!Enemy.IsReady)
                Enemy.PushToReady();
            
            if (!Player.IsReady)
                Player.PushToReady();
            
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
            Player.UnReady();
            
            Enemy.UnReady();

            if (GameParameters.Timer.Running)
                GameParameters.Timer.Stop();
        }
    }
}