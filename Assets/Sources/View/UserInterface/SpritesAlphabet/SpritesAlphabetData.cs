using System;
using System.Text;
using UnityEngine;

namespace Sources.View.UserInterface.SpritesAlphabet
{
    [CreateAssetMenu(fileName = "New sprites alphabet", menuName = "Game/UI/Sprites Alphabet", order = 0)]
    public class SpritesAlphabetData : ScriptableObject
    {
        [SerializeField] private CharIdentifier[] _identifiers;

        private const string ReplacedTagFormat = "<sprite index={0}>";

        public string GetReplacedTagOfSymbol(char symbol)
        {
            var builder = new StringBuilder(symbol.ToString());

            if (!TryGetSpriteIndexOfSymbol(symbol, out var index))
                return builder.ToString();

            builder.Clear();

            builder.Append(string.Format(ReplacedTagFormat, index));
            
            return builder.ToString();
        }

        private bool TryGetSpriteIndexOfSymbol(char symbol, out int spriteIndex)
        {
            spriteIndex = -1;

            foreach (var identifier in _identifiers)
            {
                if (identifier.Symbol != symbol)
                    continue;
                
                spriteIndex = identifier.SpriteIndex;

                return true;
            }
            
            return false;
        }

        [Serializable]
        private class CharIdentifier
        {
            [SerializeField] private char _symbol;
            
            [SerializeField] private int _spriteIndex;

            public char Symbol => _symbol;

            public int SpriteIndex => _spriteIndex;
        }
    }
}