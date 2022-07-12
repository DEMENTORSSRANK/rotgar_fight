using System;
using System.Linq;

namespace Sources.Model.Players.ReadyControl
{
    public class Readiness
    {
        private readonly ReadyHandler[] _handlers;
        
        public bool AvailableToReady => _handlers.All(x => x.IsReady);
        
        public bool IsReady { get; private set; }

        public event Action OnReady;

        public event Action OnUnReady;

        public Readiness(params ReadyHandler[] handlers)
        {
            _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }
        
        public void PushToReady()
        {
            if (IsReady)
                throw new InvalidOperationException("Already ready");

            if (AvailableToReady)
            {
                MakeReady();
                
                return;
            }

            foreach (var handler in _handlers)
            {
                handler.PushToReady();
            }

            MakeReady();
        }
        
        public void MakeReady()
        {
            if (!AvailableToReady)
                throw new InvalidOperationException("Not all available to ready");
            
            if (IsReady)
                throw new InvalidOperationException("Already ready");

            IsReady = true;

            foreach (var handler in _handlers)
                handler.OnReady();
            
            OnReady?.Invoke();
        }

        public void UnReady()
        {
            IsReady = false;
            
            OnUnReady?.Invoke();
        }
    }
}