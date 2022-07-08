using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sources.Model.Time
{
    public class LocalTimer : ITimer
    {
        private CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        private readonly int _startSeconds;

        public int RemainSeconds { get; private set; }

        public bool Running { get; private set; }

        public event Action<int> RemainSecondsChanged;

        public event Action Ended;

        public LocalTimer(int startSeconds)
        {
            if (startSeconds < 1)
                throw new ArgumentOutOfRangeException(nameof(startSeconds));

            RemainSeconds = startSeconds;
            _startSeconds = startSeconds;
        }

        public void Launch()
        {
            if (Running)
                throw new InvalidOperationException("Timer already launched");

            ChangeRemainSeconds(_startSeconds);

            Running = true;

            ProcessTickingAsync(_cancelTokenSource.Token);
        }

        public void Stop()
        {
            if (!Running)
                throw new InvalidOperationException("Timer is not launched");

            Running = false;

            _cancelTokenSource.Cancel();

            _cancelTokenSource = new CancellationTokenSource();
        }

        private async void ProcessTickingAsync(CancellationToken token)
        {
            var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
            TaskCompletionSource<int> task = new TaskCompletionSource<int>();

            tokenSource.Token.Register(() => task.SetResult(0));

            while (RemainSeconds > 0 && Running)
            {
                _cancelTokenSource.Token.ThrowIfCancellationRequested();

                await Task.WhenAny(Task.Delay(1000, CancellationToken.None), task.Task);

                if (Running)
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