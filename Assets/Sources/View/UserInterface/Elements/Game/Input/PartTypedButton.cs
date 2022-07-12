using System;
using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    [Serializable]
    public struct PartTypedButton
    {
        [SerializeField] private BodyPartType _partType;

        [SerializeField] private BoneSelectorButton _button;

        public BodyPartType PartType => _partType;

        public BoneSelectorButton Button => _button;
    }
}