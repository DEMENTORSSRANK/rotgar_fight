using System.Collections.Generic;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public interface IReadOnlyInputButtonsChooser
    {
        IEnumerable<BoneSelectorButton> Selected { get; }
    }
}