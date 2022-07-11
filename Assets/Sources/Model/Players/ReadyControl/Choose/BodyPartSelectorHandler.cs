using System;
using Sources.Model.Bodies;

namespace Sources.Model.Players.ReadyControl.Choose
{
    public class BodyPartSelectorHandler
    {
        public BodyPartSelector Selector { get; }
        
        public bool IsChoosing { get; private set; }

        public BodyPartSelectorHandler(BodyPartSelector selector)
        {
            Selector = selector ?? throw new ArgumentNullException(nameof(selector));
        }

        public async void StartChoosingAsync()
        {
            if (IsChoosing)
                throw new InvalidOperationException("Already choosing");
            
            Selector.ClearAll();

            IsChoosing = true;

            while (IsChoosing)
            {
                BodyPartType chosen = await Selector.ChoosePart();

                if (!IsChoosing)
                    break;

                if (Selector.Contains(chosen))
                    Selector.Unselect(chosen);
                else
                    Selector.SelectNew(chosen);
            }
        }

        public void StopChoosing()
        {
            IsChoosing = false;
        }
    }
}