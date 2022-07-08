using System;

namespace Sources.Model.Time
{
    public interface IReadOnlyTimer
    {
        int RemainSeconds { get; }
        
        event Action<int> RemainSecondsChanged;
        
        event Action Ended;
    }
}