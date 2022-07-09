using System;
using System.Linq;
using Sources.Model.Players.ReadyControl.Choose;

namespace Sources.Model.Players.ReadyControl
{
    public class SelectorChain : ReadyHandler
    {
        private readonly BodyPartSelectorHandler[] _handlers;

        public override bool IsReady => _handlers.All(x => x.IsChoosing);

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
        }

        public void StopAllChoosing()
        {
            foreach (var handler in _handlers)
            {
                handler.StopChoosing();
            }
        }

        public override void OnReady()
        {
            StopAllChoosing();
        }
    }
}