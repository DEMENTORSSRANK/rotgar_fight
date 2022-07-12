using System;
using System.Linq;
using Sirenix.OdinInspector;
using Sources.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.UserInterface.Elements.Game
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private ProgressSpriteWithPercent[] _progressSpritesWithPercents;

        [SerializeField] private Image _progressRender;
        
        private float _start = -1;
        
        [Button]
        public void UpdateHealth(float value)
        {
            if (_start < 0)
                throw new InvalidOperationException("Start value not inited");

            float coefficient = _start / value;

            int percents = Mathf.RoundToInt(100 / coefficient);

            int targetIndex = _progressSpritesWithPercents.Select(x => x.Percents).ToArray().LeftSegmentIndex(percents);

            UpdateProgressSprite(_progressSpritesWithPercents[targetIndex].Sprite);
        }

        private void UpdateProgressSprite(Sprite sprite)
        {
            _progressRender.sprite = sprite;
            
            _progressRender.gameObject.SetActive(sprite != null);
        }

        [Button]
        public void SetStart(float value)
        {
            _start = value;
        }

        [Serializable]
        private struct ProgressSpriteWithPercent
        {
            [SerializeField] private Sprite _sprite;

            [SerializeField] private int _percents;

            public Sprite Sprite => _sprite;

            public int Percents => _percents;
        }
    }
}