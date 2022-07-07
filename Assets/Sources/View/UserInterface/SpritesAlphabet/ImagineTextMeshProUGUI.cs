using System.Text;
using TMPro;
using UnityEngine;

namespace Sources.View.UserInterface.SpritesAlphabet
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ImagineTextMeshProUGUI : MonoBehaviour
    {
        [SerializeField] private SpritesAlphabetData _spritesAlphabet;

        [TextArea] [SerializeField] private string _debugView;

        private readonly StringBuilder _builder = new StringBuilder();

        private TextMeshProUGUI _text;

        protected void GenerateText(string input)
        {
            _builder.Clear();

            foreach (var symbol in input)
                _builder.Append(_spritesAlphabet.GetReplacedTagOfSymbol(symbol));

            _text.text = _builder.ToString();
        }

        protected virtual void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnValidate()
        { 
            if (Application.isPlaying)
                return;
            
            if (_spritesAlphabet == null)
                return;

            _text = GetComponent<TextMeshProUGUI>();
            
            GenerateText(_debugView);
        }
    }
}