using System;
using System.Linq;
using Sources.Model.Players.ReadyControl.Choose;

namespace Sources.Model.Players.ReadyControl
{
    public class SelectorChain : ReadyHandler
    {
        private readonly BodyPartSelectorHandler[] _handlers;

        public override bool IsReady => _handlers.All(x => x.IsChoosing);

        public event Action StartedChoose;

        public event Action StoppedChoose;

        public SelectorChain(params BodyPartSelectorHandler[] handlers)
        {
            _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        public void StartAllChoosing()
        {
            if (_handlers.Any(x => x.IsChoosing))
                throw new InvalidOperationException("Some of handlers already choosing");

            foreach (var handler in _handlers)
            {
                handler.StartChoosingAsync();
            }
            
            StartedChoose?.Invoke();
        }

        public void StopAllChoosing()
        {
            foreach (var handler in _handlers)
            {
                handler.StopChoosing();
            }
            
            StoppedChoose?.Invoke();
        }

        public override void OnReady()
        {
            StopAllChoosing();
        }
    }
}