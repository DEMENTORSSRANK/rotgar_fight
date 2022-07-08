using System;
using System.Reflection;
using System.Threading;
using Sources.Data;
using Sources.Input;
using Sources.Model.GameScenario;
using Sources.Model.Parameters;
using Sources.Model.Players;
using Sources.Model.Time;
using Sources.View.UserInterface.Screens;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class LocalFightCompositeRoot : MonoBehaviour
    {
        [SerializeField] private LocalGameParameters _localGameParameters;

        [SerializeField] private GameScreen _gameScreen;

        private LocalGameScenario _scenario;

        private PlayerInputRouter _inputRouter;

        private PlayerInput _playerInput;
        
        private LocalPlayer _player;

        private LocalBot _enemy;

        private LocalTimer _timer;

        private void Awake()
        {
            _player = new LocalPlayer(_localGameParameters.GenerateBaseBody(), _localGameParameters.Health,
                _localGameParameters.Damage, _localGameParameters.DefenseChooseCapacity);

            _enemy = new LocalBot(_localGameParameters.GenerateBaseBody(), _localGameParameters.Health,
                _localGameParameters.Damage, _localGameParameters.DefenseChooseCapacity,
                new TimeRange(_localGameParameters.MinBotThinkTime, _localGameParameters.MaxBotThinkTime));

            _timer = new LocalTimer(_localGameParameters.MoveSeconds);

            var gameParameters = new GameParameters(_timer, _player, _enemy);
            _scenario = new LocalGameScenario(gameParameters);

            _playerInput = new PlayerInput();
            _inputRouter = new PlayerInputRouter(_gameScreen.Input, _playerInput);

            _gameScreen.PlayerHealthView.SetStart(_player.Health.Value);
            _gameScreen.EnemyHealthView.SetStart(_enemy.Health.Value);
            
            _scenario.GameEnd += delegate(bool b) { print($"Game end ({b})"); };
        }

        private void OnEnable()
        {
            _inputRouter.Subscribe();

            _timer.RemainSecondsChanged += _gameScreen.RemainTimeView.UpdateRemain;
            
            _playerInput.AttackChosen += _player.InputAttack;
            _playerInput.DefenseChosen += _player.InputDefense;
            _playerInput.GotReady += _player.MakeReady;

            _player.Health.ValueChanged += _gameScreen.PlayerHealthView.UpdateHealth;
            _enemy.Health.ValueChanged += _gameScreen.EnemyHealthView.UpdateHealth;
        }

        private void Start()
        {
            _scenario.StartAsync();
        }

        private void OnDisable()
        {
            _inputRouter.UnSubscribe();

            _timer.RemainSecondsChanged -= _gameScreen.RemainTimeView.UpdateRemain;
            
            _playerInput.AttackChosen -= _player.InputAttack;
            _playerInput.DefenseChosen -= _player.InputDefense;
            _playerInput.GotReady -= _player.MakeReady;
            
            _player.Health.ValueChanged -= _gameScreen.PlayerHealthView.UpdateHealth;
            _enemy.Health.ValueChanged -= _gameScreen.EnemyHealthView.UpdateHealth;
        }


        private void OnApplicationQuit()
        {
#if UNITY_EDITOR
            var constructor = SynchronizationContext.Current.GetType()
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(int)}, null);
            var newContext = constructor.Invoke(new object[] {Thread.CurrentThread.ManagedThreadId});
            SynchronizationContext.SetSynchronizationContext(newContext as SynchronizationContext);
#endif
        }
    }
}