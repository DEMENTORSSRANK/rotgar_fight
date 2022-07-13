using Sources.Input;
using Sources.Model.Players;
using Sources.View.UserInterface.Elements.Game;
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

        [SerializeField] private WinScreen _win;

        [SerializeField] private LoseScreen _lose;

        private BoneButtonsDamageInfoSetter _damageInfoSetter;
        
        private EndScreenLogicView _endScreenLogicView;
        
        private LocalPlayer Player => _fight.Player;

        private LocalBot Bot => _fight.Bot;

        public IPlayerInputSender InputSender => _inputButtons.Sender;

        public override void Compose()
        {
            _inputButtons.Init();
            _gameScreen.PlayerHealthView.SetStart(_fight.Player.Health.Value);
            _gameScreen.EnemyHealthView.SetStart(_fight.Bot.Health.Value);
            _gameScreen.RemainTimeView.UpdateRemain(_fight.Timer.RemainSeconds);
            _endScreenLogicView = new EndScreenLogicView(_win, _lose);
            _damageInfoSetter = new BoneButtonsDamageInfoSetter(_fight.Player, _fight.Bot, _inputButtons.Container);
        }

        public override void Initialize()
        {
            _damageInfoSetter.SetInfo();
            
            _fight.Timer.RemainSecondsChanged += _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged += _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged += _gameScreen.EnemyHealthView.UpdateHealth;

            Player.Attacker.OnSelected += _inputButtons.Chooser.ChooseAttack;
            Player.Attacker.OnUnSelected += _inputButtons.Chooser.UnChooseAttack;

            Player.Defender.OnSelected += _inputButtons.Chooser.ChooseDefense;
            Player.Defender.OnUnSelected += _inputButtons.Chooser.UnChooseDefense;

            Player.Readiness.OnReady += _gameScreen.ReadyView.OnPlayerReady;
            Player.Readiness.OnUnReady += _gameScreen.ReadyView.OnPlayerUnReady;

            Bot.Readiness.OnReady += _gameScreen.ReadyView.OnEnemyReady;
            Bot.Readiness.OnUnReady += _gameScreen.ReadyView.OnEnemyUnReady;

            Player.PartSelectorChain.StartedChoose += _gameScreen.ReadyView.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose += _gameScreen.ReadyView.OnStopChoosing;

            Player.PartSelectorChain.StartedChoose += _inputButtons.Activator.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose += _inputButtons.Activator.OnEndChoosing;

            Player.Readiness.AvailableToReadyChanged += _inputButtons.Activator.UpdateAvailableIsReady;

            _fight.Scenario.Defeat += _endScreenLogicView.OnDefeat;
            _fight.Scenario.Won += _endScreenLogicView.OnWon;

            _win.RestartClicked += _fight.Scenario.StartAsync;
            _lose.RestartClicked += _fight.Scenario.StartAsync;

            _win.RestartClicked += _endScreenLogicView.CloseAll;
            _lose.RestartClicked += _endScreenLogicView.CloseAll;
        }

        public override void Dispose()
        {
            _fight.Timer.RemainSecondsChanged -= _gameScreen.RemainTimeView.UpdateRemain;

            Player.Health.ValueChanged -= _gameScreen.PlayerHealthView.UpdateHealth;
            Bot.Health.ValueChanged -= _gameScreen.EnemyHealthView.UpdateHealth;
            
            Player.Attacker.OnSelected -= _inputButtons.Chooser.ChooseAttack;
            Player.Attacker.OnUnSelected -= _inputButtons.Chooser.UnChooseAttack;

            Player.Defender.OnSelected -= _inputButtons.Chooser.ChooseDefense;
            Player.Defender.OnUnSelected -= _inputButtons.Chooser.UnChooseDefense;
            
            Player.Readiness.OnReady -= _gameScreen.ReadyView.OnPlayerReady;
            Player.Readiness.OnUnReady -= _gameScreen.ReadyView.OnPlayerUnReady;

            Bot.Readiness.OnReady -= _gameScreen.ReadyView.OnEnemyReady;
            Bot.Readiness.OnUnReady -= _gameScreen.ReadyView.OnEnemyUnReady;

            Player.PartSelectorChain.StartedChoose -= _gameScreen.ReadyView.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose -= _gameScreen.ReadyView.OnStopChoosing;
            
            Player.PartSelectorChain.StartedChoose -= _inputButtons.Activator.OnStartChoosing;
            Player.PartSelectorChain.StoppedChoose -= _inputButtons.Activator.OnEndChoosing;
            
            Player.Readiness.AvailableToReadyChanged -= _inputButtons.Activator.UpdateAvailableIsReady;
            
            _fight.Scenario.Defeat -= _endScreenLogicView.OnDefeat;
            _fight.Scenario.Won -= _endScreenLogicView.OnWon;
            
            _win.RestartClicked -= _fight.Scenario.StartAsync;
            _lose.RestartClicked -= _fight.Scenario.StartAsync;
            
            _win.RestartClicked -= _endScreenLogicView.CloseAll;
            _lose.RestartClicked -= _endScreenLogicView.CloseAll;
        }
    }
}