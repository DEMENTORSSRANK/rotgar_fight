using System;
using Sources.Model.Bodies;
using Sources.Model.Heal;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game
{
    public class ConsoleLogRouter
    {
        private readonly IReadOnlyHealth _player;

        private readonly IReadOnlyHealth _enemy;

        private readonly ConsoleLog _logger;

        private int _currentRound;

        public ConsoleLogRouter(ConsoleLog logger, IReadOnlyHealth player, IReadOnlyHealth enemy)
        {
            _logger = logger ? logger : throw new ArgumentNullException(nameof(logger));
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public void OnGameStarted()
        {
            _currentRound = 0;

            _logger.Clear();

            _logger.Log("<color=blue>Game</color> started");
        }

        public void OnRoundStarted()
        {
            _currentRound++;

            _logger.Log($"<color=orange>Round</color> {_currentRound} started");
            
            _logger.Log("===============================================");
        }

        public void OnGameEnd()
        {
            _logger.Log("<color=blue>Game</color> is over");
        }

        public void OnPlayerWon()
        {
            _logger.Log("===============================================");
        
            _logger.Log("<color=green>Player</color> won");
        }

        public void OnPlayerLose()
        {
            _logger.Log("<color=red>Enemy</color> won");
        }

        public void OnPlayerReady()
        {
            _logger.Log("<color=green>Player</color> ready");
        }

        public void OnEnemyReady()
        {
            _logger.Log("<color=red>Enemy</color> ready");
        }

        public void OnPlayerAttacked(BodyPartType partType, float resultDamage)
        {
            float prevValue = _enemy.Value + resultDamage;

            _logger.Log(
                $"<color=green>Player</color> hit <color=red>Enemy</color> (<color=orange>{partType}</color>) (<color=white>{prevValue}</color> - <color=orange>{resultDamage}</color> = <color=blue>{_enemy.Value}</color>)");
        }

        public void OnEnemyAttacked(BodyPartType partType, float resultDamage)
        {
            float prevValue = _player.Value + resultDamage;

            _logger.Log(
                $"<color=red>Enemy</color> hit <color=green>Player</color> (<color=orange>{partType}</color>) (<color=white>{prevValue}</color> - <color=orange>{resultDamage}</color> = <color=blue>{_player.Value}</color>)");
            
            _logger.Log("===============================================");
        }
    }
}