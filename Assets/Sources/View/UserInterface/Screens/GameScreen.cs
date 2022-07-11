using System;
using Sources.Input;
using Sources.View.UserInterface.Elements.Game;
using Sources.View.UserInterface.SpritesAlphabet;
using UnityEngine;

namespace Sources.View.UserInterface.Screens
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private InputButtons _inputButtons;

        [SerializeField] private TimerView _remainTimeView;

        [SerializeField] private HealthBar _playerHealthView;

        [SerializeField] private HealthBar _enemyHealthView;

        public IPlayerInputSender Input => _inputButtons;

        public TimerView RemainTimeView => _remainTimeView;

        public HealthBar PlayerHealthView => _playerHealthView;

        public HealthBar EnemyHealthView => _enemyHealthView;

        private void Start()
        {
            _inputButtons.Start();
        }

        [Serializable]
        public class TimerView
        {
            [SerializeField] private ImagineTextMeshProUGUI _view;

            public void UpdateRemain(int seconds)
            {
                _view.GenerateText(seconds);
            }
        }
    }
}