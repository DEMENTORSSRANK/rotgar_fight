using System;

namespace Sources.Model.Players.ReadyControl
{
    public abstract class ReadyHandler
    {
        public abstract bool IsReady { get; }
        
        // TODO: Compliance contract
        public abstract event Action ReadyChanged;
        
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