using System.Threading.Tasks;
using Sources.Model.Parameters;
using Sources.Model.Time;

namespace Sources.Model.GameScenario
{
    public class LocalGameScenario : BaseGameScenario
    {
        private readonly LocalTimer _moveTimer;

        public LocalGameScenario(IGameParameters gameParameters) : base(gameParameters)
        {
            _moveTimer = new LocalTimer(gameParameters.MoveSeconds);
        }
        
        protected override async Task ProcessMoveAsync()
        {
            _moveTimer.Launch();
            
            GameParameters.Player.ChooseAttack();

            GameParameters.Player.ChooseDefense();

            GameParameters.Enemy.ChooseAttack();

            GameParameters.Enemy.ChooseDefense();
            
            while (_moveTimer.Running)
            {
                await Task.Delay(1);
            }
        }
    }
}