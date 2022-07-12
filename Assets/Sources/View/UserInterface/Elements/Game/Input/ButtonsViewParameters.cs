using System;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    [Serializable]
    public class ButtonsViewParameters
    {
        [SerializeField] private Color _default = Color.white;
        
        [SerializeField] private Color _chosen = Color.red;

        public Color Default => _default;

        public Color Chosen => _chosen;
    }
}