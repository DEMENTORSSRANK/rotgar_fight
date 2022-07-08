using System;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.Data
{
    [CreateAssetMenu(fileName = "New game parameters", menuName = "Game/Parameters", order = 0)]
    public class LocalGameParameters : ScriptableObject
    {
        [Min(1)] [SerializeField] private int _defenseChooseCapacity = 1;

        [Min(1)] [SerializeField] private int _attackChooseCapacity = 1;

        [Min(1)] [SerializeField] private int _damage = 1;

        [Min(1)] [SerializeField] private int _health = 1;

        [Min(0)] [SerializeField] private float _minBotThinkTime = .5f;

        [Min(1)] [SerializeField] private int _moveSeconds = 1;

        [OnValueChanged(nameof(OnMaxBotThinkTimeChanged))] [Min(0)] [SerializeField]
        private float _maxBotThinkTime = 1;

        [SerializeField] private PartTypeWithPercentsDamage[] _partTypeWithPercents;

        public int MoveSeconds => _moveSeconds;

        public int DefenseChooseCapacity => _defenseChooseCapacity;

        public int AttackChooseCapacity => _attackChooseCapacity;

        public float MinBotThinkTime => _minBotThinkTime;

        public float MaxBotThinkTime => _maxBotThinkTime;

        public int Damage => _damage;

        public int Health => _health;

        public Body GenerateBaseBody()
        {
            return new Body(_partTypeWithPercents.Select(GenerateOfItem).ToArray());
        }

        private void OnMaxBotThinkTimeChanged(float value)
        {
            _maxBotThinkTime = Mathf.Clamp(_maxBotThinkTime, _minBotThinkTime, _maxBotThinkTime);
        }

        private static BodyPart GenerateOfItem(PartTypeWithPercentsDamage partTypeWithPercentsDamage)
        {
            return new BodyPart(partTypeWithPercentsDamage.PartType, partTypeWithPercentsDamage.Percents);
        }

        [Serializable]
        private struct PartTypeWithPercentsDamage
        {
            [SerializeField] private BodyPartType _partType;

            [Range(1, 250)] [SerializeField] private int _percents;

            public BodyPartType PartType => _partType;

            public int Percents => _percents;
        }
    }
}