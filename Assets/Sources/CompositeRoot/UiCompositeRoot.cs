using Sources.Input;
using Sources.Model.Players;
using Sources.View.UserInterface.Screens;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class UiCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private GameScreen _gameScreen;

        [SerializeField] private LocalFightCompositeRoot _fight;

        public IPlayerInputSender Input => _gameScreen.Input;

        private LocalPlayer Player => _fight.Player;

        private LocalBot Bot => _fight.Bot;

        public override void Compose()
        {
            _gameScreen.PlayerHealthView.SetStart(_fight.Player.Health.Value);
            _gameScreen.EnemyHealthView.SetStart(_fight.Bot.Health.Value);
        }

        public override void Enable()
        {
            _fight.Timer.RemainSecondsChanged += _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged += _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged += _gameScreen.EnemyHealthView.UpdateHealth;
        }

        public override void Dispose()
        {
            _fight.Timer.RemainSecondsChanged -= _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged -= _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged -= _gameScreen.EnemyHealthView.UpdateHealth;
        }
    }
}