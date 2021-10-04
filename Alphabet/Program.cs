using System;
using System.Collections;

namespace Alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            Alphabet alphabet = new Alphabet();
            int number = alphabet["I"];
            Console.WriteLine(number);
            foreach (var item in alphabet)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Alphabet : IEnumerable
    {
        private string[] _items = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public int this[string key]
        {
            get
            {
                return GetIndexOfLetter(key);
            }
        }

        private int GetIndexOfLetter(string key)
        {
            int defaultletter = 0;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == key)
                    defaultletter = i;
            }
            defaultletter++;
            return defaultletter;
        }
        public IEnumerator GetEnumerator()
        {
            return new _AlphabetEnumerator(_items, _items.Length);
        }
    }
    public class _AlphabetEnumerator : IEnumerator
    {
        private int _counter = 0;
        private readonly int _size;
        private readonly string[] _source;
        public _AlphabetEnumerator(string[] source, int size)
        {
            _source = source;
            _size = size;
        }
        public object Current => _source[_counter++];

        public bool MoveNext()
        {
            return _counter < _size;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}