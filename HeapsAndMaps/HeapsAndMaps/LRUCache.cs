using System;
using System.Collections.Generic;

namespace HeapsAndMaps
{
    public class LRUCache
    {
        private readonly Dictionary<int, int> _dict;
        private readonly int _capacity;
        private readonly int[] _frequencyUsing;

        public LRUCache(int capacity)
        {
            _dict = new Dictionary<int, int>();
            _capacity = capacity;
            _frequencyUsing = new int[_capacity];
        }

        public int Get(int key)
        {
            if (_dict.ContainsKey(key))
            {
                RemoveFrequencyUsing(key);
                AddFrequencyUsing(key);

                return _dict[key];
            }

            return -1;
        }

        public void Set(int key, int value)
        {
            if(_dict.Count >= _capacity && !_dict.ContainsKey(key))
            {
                _dict.Remove(_frequencyUsing[0]);
                RemoveFrequencyUsing(_frequencyUsing[0]);
            }

            if (!_dict.ContainsKey(key))
            {
                _dict.Add(key, value);
                AddFrequencyUsing(key);
            }
            else
            {
                _dict[key] = value;
                RemoveFrequencyUsing(key);
                AddFrequencyUsing(key);
            }
        }

        private void RemoveFrequencyUsing(int key)
        {
            // O(n)
            var deletedIndex = -1;
            for(int i = 0; i < _frequencyUsing.Length; i++)
            {
                if(_frequencyUsing[i] == key)
                {
                    _frequencyUsing[i] = 0;
                    deletedIndex = i;
                    break;
                }
            }

            if(deletedIndex == -1)
            {
                return;
            }

            for(int i = deletedIndex + 1; i < _frequencyUsing.Length; i++)
            {
                var temp = _frequencyUsing[i];
                _frequencyUsing[i] = _frequencyUsing[i - 1];
                _frequencyUsing[i - 1] = temp;
            }
        }

        private void AddFrequencyUsing(int key)
        {
            for(int i = 0; i < _frequencyUsing.Length; i++)
            {
                if(_frequencyUsing[i] == 0)
                {
                    _frequencyUsing[i] = key;

                    return;
                }
            }
        }
    }
}
