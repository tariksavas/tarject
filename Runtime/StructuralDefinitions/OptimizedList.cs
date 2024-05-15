using System;
using UnityEngine;

namespace Tarject.Runtime.StructuralDefinitions
{
    [Serializable]
    public class OptimizedList<T>
    {
        public T this[int i] => _array[i];

        public int Count => _array.Length;
        
        [SerializeField]
        private T[] _array;

        public OptimizedList()
        {
            _array = Array.Empty<T>();
        }

        public OptimizedList(T t)
        {
            _array = new T[1];

            _array[0] = t;
        }

        public OptimizedList(T[] tArray)
        {
            _array = new T[tArray.Length];

            for (int index = 0; index < tArray.Length; index++)
            {
                _array[index] = tArray[index];
            }
        }

        public OptimizedList(OptimizedList<T> optimizedList)
        {
            new OptimizedList<T>();
            Add(optimizedList);
        }

        public void Add(T t)
        {
            Array.Resize(ref _array, _array.Length + 1);

            _array[^1] = t;
        }

        public void Add(OptimizedList<T> optimizedList)
        {
            for (int i = 0; i < optimizedList.Count; i++)
            {
                Add(optimizedList[i]);
            }
        }

        public void Remove(T t)
        {
            int removeIndex = 0;

            for (int index = 0; index < _array.Length; index++)
            {
                if (t.Equals(_array[index]))
                {
                    removeIndex = index;
                }
            }

            RemoveAt(removeIndex);
        }

        public void RemoveAt(int removeIndex)
        {
            for (int index = removeIndex; index < _array.Length - 1; index++)
            {
                _array[index] = _array[index + 1];
            }

            Array.Resize(ref _array, _array.Length - 1);
        }

        public void Clear()
        {
           new OptimizedList<T>();
        }

        public bool Contains(T t)
        {
            for (int index = 0; index < _array.Length; index++)
            {
                if (_array[index].Equals(t))
                {
                    return true;
                }
            }

            return false;
        }

        public T Find(Predicate<T> match)
        {
            T matchedElement = default;

            for (int index = 0; index < _array.Length; index++)
            {
                if (match(_array[index]))
                {
                    matchedElement = _array[index];
                    break;
                }
            }

            return matchedElement;
        }

        public OptimizedList<T> FindAll(Predicate<T> match)
        {
            OptimizedList<T> matchedElements = new OptimizedList<T>();

            for (int index = 0; index < _array.Length; index++)
            {
                if (match(_array[index]))
                {
                    matchedElements.Add(_array[index]);
                }
            }

            return matchedElements;
        }
        
        public bool Exist(Predicate<T> match)
        {
            for (int index = 0; index < _array.Length; index++)
            {
                if (match(_array[index]))
                {
                    return true;
                }
            }

            return false;
        }

        public void ForEach(Action<T> match)
        {
            for (int index = 0; index < _array.Length; index++)
            {
                match(_array[index]);
            }
        }
    }
}