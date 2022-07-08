using System;
using Sources.Input;
using Sources.Model.Bodies;
using Sources.View.UserInterface.Elements.Game;
using Sources.View.UserInterface.SpritesAlphabet;
using UnityEngine;
using UnityEngine.UI;

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
        private class InputButtons : IPlayerInputSender
        {
            [SerializeField] private PartTypedButton[] _attackPartTypedButtons;
        
            [SerializeField] private PartTypedButton[] _defensePartTypedButtons;

            [SerializeField] private Button _ready;
        
            public event Action<BodyPartType> OnAttackChosen;
        
            public event Action<BodyPartType> OnDefenseChosen;
        
            public event Action OnGetReady;

            private void AttackChoose(BodyPartType partType)
            {
                OnAttackChosen?.Invoke(partType);
            }

            private void DefenseChoose(BodyPartType partType)
            {
                OnDefenseChosen?.Invoke(partType);
            }

            private void ReadyClicked()
            {
                OnGetReady?.Invoke();
            }
        
            public void Start()
            {
                foreach (var attackPartTypedButton in _attackPartTypedButtons)
                {
                    attackPartTypedButton.Button.onClick.AddListener(delegate
                    {
                        AttackChoose(attackPartTypedButton.PartType);
                    });
                }

                foreach (var defensePartTypedButton in _defensePartTypedButtons)
                {
                    defensePartTypedButton.Button.onClick.AddListener(delegate
                    {
                        DefenseChoose(defensePartTypedButton.PartType);
                    });
                }
            
                _ready.onClick.AddListener(ReadyClicked);
            }
            
            [Serializable]
            private struct PartTypedButton
            {
                [SerializeField] private BodyPartType _partType;

                [SerializeField] private Button _button;

                public BodyPartType PartType => _partType;

                public Button Button => _button;
            }
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