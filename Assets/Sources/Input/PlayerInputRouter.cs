using System;

namespace Sources.Input
{
    public class PlayerInputRouter
    {
        private readonly IPlayerInputSender _inputSender;

        private readonly PlayerInput _playerInput;

        public PlayerInputRouter(IPlayerInputSender inputSender, PlayerInput playerInput)
        {
            _inputSender = inputSender ?? throw new ArgumentNullException(nameof(inputSender));
            _playerInput = playerInput ?? throw new ArgumentNullException(nameof(playerInput));
        }

        public void Subscribe()
        {
            _inputSender.OnAttackChosen += _playerInput.ChooseAttack;
            
            _inputSender.OnDefenseChosen += _playerInput.ChooseDefense;

            _inputSender.OnGetReady += _playerInput.CompleteChoose;
        }

        public void UnSubscribe()
        {
            _inputSender.OnAttackChosen -= _playerInput.ChooseAttack;
            
            _inputSender.OnDefenseChosen -= _playerInput.ChooseDefense;

            _inputSender.OnGetReady -= _playerInput.CompleteChoose;
        }
    }
}