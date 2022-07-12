using System;

namespace Sources.Model.Heal
{
    public interface IReadOnlyHealth
    {
        float Value { get; }
        
        bool IsDead { get; }

        event Action<float> ValueChanged;

        event Action Dead;

        void ResetToStartValue();
    }
}