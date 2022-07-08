using System;
using System.Threading.Tasks;

namespace Sources.Model.Time
{
    public class LocalTimer : ITimer
    {
        private readonly int _startSeconds;
        
        public int RemainSeconds { get; private set; }

        public bool Running { get; private set; }

        public event Action<int> RemainSecondsChanged;

        public event Action Ended;
        
        public LocalTimer(int startSeconds)
        {
            if (startSeconds < 1)
                throw new ArgumentOutOfRangeException(nameof(startSeconds));

            _startSeconds = startSeconds;
            RemainSeconds = startSeconds;
        }

        public void Launch()
        {
            if (Running)
                throw new InvalidOperationException("Timer already launched");

            ChangeRemainSeconds(_startSeconds);
            
            Running = true;

            ProcessTickingAsync();
        }

        private async void ProcessTickingAsync()
        {
            while (RemainSeconds > 0)
            {
                await Task.Delay(1000);

                ChangeRemainSeconds(--RemainSeconds);
            }
            
            Ended?.Invoke();

            Running = false;
        }

        private void ChangeRemainSeconds(int seconds)
        {
            RemainSeconds = seconds;
            
            RemainSecondsChanged?.Invoke(seconds);
        }
    }
}