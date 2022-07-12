using System;
using System.Reflection;
using System.Threading;
using Sources.Data;
using Sources.Model.GameScenario;
using Sources.Model.Parameters;
using Sources.Model.Players;
using Sources.Model.Time;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class LocalFightCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private LocalPlayersCompositeRoot _localPlayers;

        private LocalGameParameters GameParameters => _localPlayers.Parameters;

        public LocalGameScenario Scenario { get; private set; }
        
        public LocalTimer Timer { get; private set; }

        public LocalPlayer Player => _localPlayers.Player;

        public LocalBot Bot => _localPlayers.Enemy;

        public override void Compose()
        {
            Timer = new LocalTimer(GameParameters.MoveSeconds);

            var gameParameters =
                new GameParameters(Timer, Player, Bot, GameParameters.AttackDelay, GameParameters.MoveDelay);
            
            Scenario = new LocalGameScenario(gameParameters);
        }

        private void Start()
        {
            Scenario.StartAsync();
        }

        private void OnApplicationQuit()
        {
#if UNITY_EDITOR
            ConstructorInfo constructor = SynchronizationContext.Current.GetType()
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {typeof(int)}, null);

            if (constructor == null)
                return;

            object newContext = constructor.Invoke(new object[] {Thread.CurrentThread.ManagedThreadId});

            SynchronizationContext.SetSynchronizationContext(newContext as SynchronizationContext);
#endif
        }
    }
}