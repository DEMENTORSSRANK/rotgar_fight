using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Model.Bodies;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    [Serializable]
    public class ButtonsContainer
    {
        [SerializeField] private PartTypedButton[] _attackPartTypedButtons;

        [SerializeField] private PartTypedButton[] _defensePartTypedButtons;

        [SerializeField] private Button _ready;

        public IEnumerable<PartTypedButton> AttackButtons => _attackPartTypedButtons;

        public IEnumerable<PartTypedButton> DefenseButtons => _defensePartTypedButtons;

        public Button Ready => _ready;

        public BoneSelectorButton GetDefenseButtonByType(BodyPartType partType) =>
            _defensePartTypedButtons.First(x => x.PartType == partType).Button;

        public BoneSelectorButton GetAttackButtonByType(BodyPartType partType) =>
            _attackPartTypedButtons.First(x => x.PartType == partType).Button;
    }
}