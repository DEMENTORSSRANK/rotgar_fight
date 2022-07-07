using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace Sources.View.UserInterface.SpritesAlphabet
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(LocalizeStringEvent))]
    public class ImagineTextMeshProUGUILocalizeEvent : ImagineTextMeshProUGUI
    {
        private LocalizeStringEvent _stringEvent;

        protected override void Awake()
        {
            base.Awake();

            _stringEvent = GetComponent<LocalizeStringEvent>();
        }

        private void OnEnable()
        {
            _stringEvent.OnUpdateString.AddListener(GenerateText);
        }

        private void OnDisable()
        {
            _stringEvent.OnUpdateString.RemoveListener(GenerateText);
        }
    }
}