using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game
{
    public class ConsoleLog : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private readonly StringBuilder _builder = new StringBuilder();

        public void Log(object value)
        {
            var stringValue = value.ToString();
            
            if (string.IsNullOrEmpty(stringValue))
                throw new ArgumentException("Log value cant be empty or null");

            if (_builder.Length > 0)
                _builder.Append('\n');
            
            _builder.Append(value);

            _text.text = _builder.ToString();
        }

        public void Clear()
        {
            _text.text = string.Empty;
            _builder.Clear();
        }
    }
}