using System;
using System.Linq;

namespace GenericList
{
    public class GenericsList<T>
    {
        const int DefaultCapacity = 100;

        private T[] elements;
        private int count = 0;

        public GenericsList() : this(DefaultCapacity)
	    {
	    }

        public GenericsList(int capacity)
        {
            elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            if (Count >= elements.Length)
            {
                T[] tempArray = new T[elements.Length * 2];
                Array.Copy(elements, 0, tempArray, 0, elements.Length);
                elements = tempArray;
            }
            
            this.elements[Count] = element;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                
                T result = elements[index];
                return result;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            
            for (int i = index; i < Count; i++)
            {
                elements[i] = elements[i + 1];  
            }
            count--;
        }

        public void Insert(T element, int index)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            
            count++;
            for (int i = Count - 1; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }
            elements[index] = element;

        }

        public void ClearList()
        {
            int capacity = elements.Length;
            elements = new T[capacity];
        }

        public int Find(T value)
        {
            return (Array.IndexOf(elements, value));
        }

        public override string ToString()
        {
            string result = string.Join(",", elements.Select(x => x.ToString()).ToArray());

            return result;
        }
    }
}
