namespace Sources.Model.Players.ReadyControl
{
    public abstract class ReadyHandler
    {
        public abstract bool IsReady { get; }

        public void PushToReady()
        {
            OnPushingToReady();
        }

        protected virtual void OnPushingToReady()
        {
            
        }

        public virtual void OnReady()
        {
            
        }
    }
}