using System;
using System.Collections;

namespace IEnumerator_Spectrum
{
    class Program
    {
        static void Main(string[] args)
        {
            Spectrum sp = new Spectrum();
            foreach (string color in sp)
            {
                Console.WriteLine(color);
            }
        }
    }

    //枚举器
    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;

        public ColorEnumerator(string[] theColors)
        {
            _colors = new string[theColors.Length];
            for (int i = 0; i < theColors.Length; i++)
            {
                _colors[i] = theColors[i];
            }
        }
        public object Current
        {
            get
            {
                if (_position == -1)
                {
                    throw new InvalidOperationException();
                }
                if (_position >= _colors.Length)
                {
                    throw new InvalidOperationException();
                }
                return _colors[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _colors.Length - 1)
            {
                _position++;
                return true;
            }
            else
                return false; 
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    //可枚举类： 负责返回一个枚举器IEnumerator
    class Spectrum : IEnumerable
    {
        string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red"};
        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(Colors);
        }
    }
}
