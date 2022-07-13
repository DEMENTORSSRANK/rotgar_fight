using Sources.Model.Players;
using Sources.View.Character;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class CharacterViewCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private LocalPlayersCompositeRoot _players;

        [SerializeField] private LocalFightCompositeRoot _fight;
        
        [SerializeField] private SpineController _spinePlayer;

        [SerializeField] private SpineController _spineEnemy;

        private BasePlayer Player => _players.Player;

        private BasePlayer Enemy => _players.Enemy;

        private SpineAnimator PlayerAnimator => _spinePlayer.Animator;

        private SpineAnimator EnemyAnimator => _spineEnemy.Animator;

        public override void Compose()
        {
            _spineEnemy.Init();
            
            _spinePlayer.Init();
        }

        public override void Initialize()
        {
            Player.Attacker.Attacked += PlayerAnimator.AttackToBodyPart;
            Enemy.Attacker.Attacked += EnemyAnimator.AttackToBodyPart;

            Player.DamageTaker.Blocked += PlayerAnimator.Block;
            Enemy.DamageTaker.Blocked += EnemyAnimator.Block;
            
            Player.Health.Dead += PlayerAnimator.Die;
            Enemy.Health.Dead += EnemyAnimator.Die;
            
            _fight.Scenario.GameStarted += PlayerAnimator.ToIdle;
            _fight.Scenario.GameStarted += EnemyAnimator.ToIdle;

            Player.DamageTaker.Hit += _spinePlayer.HitView.PlayHitOfPartAsync;
            Enemy.DamageTaker.Hit += _spineEnemy.HitView.PlayHitOfPartAsync;
        }

        public override void Dispose()
        {
            Player.Attacker.Attacked -= _spinePlayer.Animator.AttackToBodyPart;
            Enemy.Attacker.Attacked -= _spineEnemy.Animator.AttackToBodyPart;

            Player.DamageTaker.Blocked -= PlayerAnimator.Block;
            Enemy.DamageTaker.Blocked -= EnemyAnimator.Block;
            
            Player.Health.Dead -= PlayerAnimator.Die;
            Enemy.Health.Dead -= EnemyAnimator.Die;
            
            _fight.Scenario.GameStarted -= PlayerAnimator.ToIdle;
            _fight.Scenario.GameStarted -= EnemyAnimator.ToIdle;
            
            Player.DamageTaker.Hit -= _spinePlayer.HitView.PlayHitOfPartAsync;
            Enemy.DamageTaker.Hit -= _spineEnemy.HitView.PlayHitOfPartAsync;
        }
    }
}