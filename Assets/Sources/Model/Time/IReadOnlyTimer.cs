using System;

namespace Sources.Model.Time
{
    public interface IReadOnlyTimer
    {
        bool Running { get; }
        
        int RemainSeconds { get; }
        
        event Action<int> RemainSecondsChanged;
        
        event Action Ended;
    }
}