namespace Sources.Model.Time
{
    public interface ITimer : IReadOnlyTimer
    {
        void Launch();

        void Stop();
    }
}