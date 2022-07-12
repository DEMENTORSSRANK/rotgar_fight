using Sources.Input;
using Sources.Model.Players;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class LocalPlayerInputCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private UiCompositeRoot _ui;

        [SerializeField] private LocalPlayersCompositeRoot _players;
        
        private PlayerInputRouter _inputRouter;

        private PlayerInput _playerInput;

        private LocalPlayer Player => _players.Player;

        public override void Compose()
        {
            _playerInput = new PlayerInput();
            
            _inputRouter = new PlayerInputRouter(_ui.Input, _playerInput);
        }

        public override void Enable()
        {
            _inputRouter.Subscribe();
            
            _playerInput.AttackChosen += Player.InputAttack;
            _playerInput.DefenseChosen += Player.InputDefense;
            _playerInput.GotReady += Player.Readiness.MakeReady;
        }

        public override void Dispose()
        {
            _inputRouter.UnSubscribe();
            
            _playerInput.AttackChosen -= Player.InputAttack;
            _playerInput.DefenseChosen -= Player.InputDefense;
            _playerInput.GotReady -= Player.Readiness.MakeReady;
        }
    }
}