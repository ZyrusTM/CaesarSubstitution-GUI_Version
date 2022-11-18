using System;
using System.Text.RegularExpressions;

namespace CaesarSubstitution_GUI_Version
{
    internal class CaesarSubstitution
    {
        private char[] _textArray;
        private int _key;

        public void SetData(string text, int key)
        {
            if (_textArray != null)
            {
                Array.Clear(_textArray, 0, _textArray.Length);
            }

            text = Regex.Replace(text, " ", "");
            _textArray = ToUpperCase(text).ToCharArray();
            _key = key;
        }

        private string ToUpperCase(string text)
        {
            string InUpper = "";

            foreach (char c in text)
            {
                if ((int)c >= 97)
                {
                    int UpperCaseAscii = (int)c - 32;
                    InUpper += (char)UpperCaseAscii;
                }
                else
                {
                    InUpper += c;
                }
            }
            return InUpper;
        }

        public string Encrypt()
        {
            string encText = "";
            foreach (char c in _textArray)
            {
                var ascii = (int)c;
                ascii -= 65;
                int encAscii = (ascii + _key) % 26;
                encAscii += 65;
                encText += (char)encAscii;
            }
            return encText;
        }

        public string Decrypt()
        {
            string decText = "";

            foreach (char c in _textArray)
            {
                var ascii = (int)c;
                ascii -= 65;
                int decAscii = (ascii - _key) % 26;
                if (decAscii < 0)
                {
                    decAscii += 26;
                }
                decAscii += 65;
                decText += (char)decAscii;
            }
            return decText;
        }
    }
}