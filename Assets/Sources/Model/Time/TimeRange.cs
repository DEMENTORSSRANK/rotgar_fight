using System;

namespace Sources.Model.Time
{
    public class TimeRange
    {
        private readonly Random _random = new Random();
        
        public float Min { get; }

        public float Max { get; }

        public float Range => Max - Min;

        public float Random
        {
            get
            {
                double sample = _random.NextDouble();
                
                double scaled = sample * Range + Min;

                return (float) scaled;
            }
        }

        public TimeRange(float min, float max)
        {
            if (min < 0)
                throw new ArgumentOutOfRangeException(nameof(min));
            
            if (max < min)
                throw new ArgumentOutOfRangeException(nameof(max));
            
            Min = min;
            Max = max;
        }
    }
}