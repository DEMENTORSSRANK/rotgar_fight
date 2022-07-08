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
            
            Enemy.Attacker.Attack(Player);
        }
    }
}