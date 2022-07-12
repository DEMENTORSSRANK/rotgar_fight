using Sources.Input;
using Sources.Model.Players;
using Sources.View.UserInterface.Elements.Game.Input;
using Sources.View.UserInterface.Screens;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class UiCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private GameScreen _gameScreen;

        [SerializeField] private LocalFightCompositeRoot _fight;

        [SerializeField] private InputButtons _inputButtons;

        private LocalPlayer Player => _fight.Player;

        private LocalBot Bot => _fight.Bot;

        public IPlayerInputSender InputSender => _inputButtons.Sender;

        public override void Compose()
        {
            _inputButtons.Init();
            _gameScreen.PlayerHealthView.SetStart(_fight.Player.Health.Value);
            _gameScreen.EnemyHealthView.SetStart(_fight.Bot.Health.Value);
        }

        public override void Enable()
        {
            _fight.Timer.RemainSecondsChanged += _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged += _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged += _gameScreen.EnemyHealthView.UpdateHealth;

            Player.Attacker.OnSelected += _inputButtons.View.ChooseAttack;
            Player.Attacker.OnUnSelected += _inputButtons.View.UnChooseAttack;

            Player.Defender.OnSelected += _inputButtons.View.ChooseDefense;
            Player.Defender.OnUnSelected += _inputButtons.View.UnChooseDefense;

            Player.Readiness.OnReady += _gameScreen.ReadyView.OnPlayerReady;
            Player.Readiness.OnUnReady += _gameScreen.ReadyView.OnPlayerUnReady;

            Bot.Readiness.OnReady += _gameScreen.ReadyView.OnEnemyReady;
            Bot.Readiness.OnUnReady += _gameScreen.ReadyView.OnEnemyUnReady;

            Player.PartSelectorChain.StartedChoose += _gameScreen.ReadyView.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose += _gameScreen.ReadyView.OnStopChoosing;
        }

        public override void Dispose()
        {
            _fight.Timer.RemainSecondsChanged -= _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged -= _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged -= _gameScreen.EnemyHealthView.UpdateHealth;
            
            Player.Attacker.OnSelected -= _inputButtons.View.ChooseAttack;
            Player.Attacker.OnUnSelected -= _inputButtons.View.UnChooseAttack;

            Player.Defender.OnSelected -= _inputButtons.View.ChooseDefense;
            Player.Defender.OnUnSelected -= _inputButtons.View.UnChooseDefense;
            
            Player.Readiness.OnReady -= _gameScreen.ReadyView.OnPlayerReady;
            Player.Readiness.OnUnReady -= _gameScreen.ReadyView.OnPlayerUnReady;

            Bot.Readiness.OnReady -= _gameScreen.ReadyView.OnEnemyReady;
            Bot.Readiness.OnUnReady -= _gameScreen.ReadyView.OnEnemyUnReady;

            Player.PartSelectorChain.StartedChoose -= _gameScreen.ReadyView.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose -= _gameScreen.ReadyView.OnStopChoosing;
        }
    }
}