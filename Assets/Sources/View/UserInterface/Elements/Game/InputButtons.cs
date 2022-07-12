using System;
using Sources.Input;
using Sources.Model.Bodies;
using Sources.View.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Elements.Game
{
    [Serializable]
    public class InputButtons : IPlayerInputSender
    {
        [SerializeField] private PartTypedButton[] _attackPartTypedButtons;

        [SerializeField] private PartTypedButton[] _defensePartTypedButtons;

        [SerializeField] private Button _ready;

        public event Action<BodyPartType> OnAttackChosen;

        public event Action<BodyPartType> OnDefenseChosen;

        public event Action OnGetReady;

        public void UpdatePlayerBoneContainer(BoneContainer boneContainer)
        {
            
        }

        public void UpdateEnemyBoneContainer(BoneContainer boneContainer)
        {
            
        }

        public void UpdatePlayerBody(Body body)
        {
            
        }

        public void UpdateEnemyBody(Body body)
        {
            
        }

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
                attackPartTypedButton.Button.OnClicked += delegate
                {
                    AttackChoose(attackPartTypedButton.PartType);
                };
            }

            foreach (var defensePartTypedButton in _defensePartTypedButtons)
            {
                defensePartTypedButton.Button.OnClicked += delegate
                {
                    DefenseChoose(defensePartTypedButton.PartType);
                };
            }

            _ready.onClick.AddListener(ReadyClicked);
        }

        [Serializable]
        private struct PartTypedButton
        {
            [SerializeField] private BodyPartType _partType;

            [SerializeField] private BoneSelectorButton _button;

            public BodyPartType PartType => _partType;

            public BoneSelectorButton Button => _button;
        }
    }
}