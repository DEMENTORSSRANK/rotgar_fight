using System;
using UnityEngine;

namespace Sources.Model.Heal
{
    public class Health
    {
        private readonly float _startValue;
        
        public float Value { get; private set; }

        public bool IsDead => Value <= 0;
        
        public event Action<float> ValueChanged;

        public event Action Dead;

        public Health(float value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _startValue = value;
            ResetToStartValue();
        }

        public void ApplyDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            Value = Mathf.Clamp(Value - damage, 0, Value);
            
            ValueChanged?.Invoke(Value);
            
            TryDie();
        }

        public void ResetToStartValue()
        {
            Value = _startValue;
            
            ValueChanged?.Invoke(Value);
        }

        private void TryDie()
        {
            if (Value > 0)
                return;
            
            Dead?.Invoke();
        }
    }
}