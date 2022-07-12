using System;
using Sources.View.UserInterface.Elements.Game;
using Sources.View.UserInterface.SpritesAlphabet;
using UnityEngine;

namespace Sources.View.UserInterface.Screens
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private TimerView _remainTimeView;

        [SerializeField] private HealthBar _playerHealthView;

        [SerializeField] private HealthBar _enemyHealthView;

        [SerializeField] private ReadyView _readyView;

        public TimerView RemainTimeView => _remainTimeView;

        public HealthBar PlayerHealthView => _playerHealthView;

        public HealthBar EnemyHealthView => _enemyHealthView;

        public ReadyView ReadyView => _readyView;

        private void Start()
        {
            _readyView.InActiveAll();
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