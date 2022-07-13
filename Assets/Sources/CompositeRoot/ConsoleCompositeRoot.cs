using Sources.View.UserInterface.Elements.Game;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class ConsoleCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private LocalFightCompositeRoot _fight;
        
        [SerializeField] private ConsoleLog _console;

        private ConsoleLogRouter _router;

        public override void Compose()
        {
            _router = new ConsoleLogRouter(_console, _fight.Player.Health, _fight.Bot.Health);
        }

        public override void Initialize()
        {
            _fight.Scenario.GameStarted += _router.OnGameStarted;
            _fight.Scenario.RoundStarted += _router.OnRoundStarted;
            
            _fight.Scenario.GameEnd += _router.OnGameEnd;
            _fight.Scenario.Won += _router.OnPlayerWon;
            _fight.Scenario.Defeat += _router.OnPlayerLose;

            _fight.Player.Readiness.OnReady += _router.OnPlayerReady;
            _fight.Bot.Readiness.OnReady += _router.OnEnemyReady;

            _fight.Player.Attacker.AttackedWithDamage += _router.OnPlayerAttacked;
            _fight.Bot.Attacker.AttackedWithDamage += _router.OnEnemyAttacked;
        }

        public override void Dispose()
        {
            _fight.Scenario.GameStarted -= _router.OnGameStarted;
            _fight.Scenario.RoundStarted -= _router.OnRoundStarted;
            
            _fight.Scenario.GameEnd -= _router.OnGameEnd;
            _fight.Scenario.Won -= _router.OnPlayerWon;
            _fight.Scenario.Defeat -= _router.OnPlayerLose;
            
            _fight.Player.Readiness.OnReady -= _router.OnPlayerReady;
            _fight.Bot.Readiness.OnReady -= _router.OnEnemyReady;
            
            _fight.Player.Attacker.AttackedWithDamage -= _router.OnPlayerAttacked;
            _fight.Bot.Attacker.AttackedWithDamage -= _router.OnEnemyAttacked;
        }
    }
}