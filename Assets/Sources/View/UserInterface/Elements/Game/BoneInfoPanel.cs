using System;
using Sources.Model.Bodies;
using TMPro;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game
{
    [Serializable]
    public class BoneInfoPanel
    {
        [SerializeField] private GameObject _mainPanel;

        [SerializeField] private TMP_Text _info;

        [TextArea] [SerializeField] private string _format = "{0}\nExp. damage: {1}";

        public void SetInfo(BodyPartType partType, float expectDamage)
        {
            _info.text = string.Format(_format, partType, expectDamage);
        }

        public void Activate()
        {
            _mainPanel.SetActive(true);
        }

        public void DeActive()
        {
            _mainPanel.SetActive(false);
        }
    }
}