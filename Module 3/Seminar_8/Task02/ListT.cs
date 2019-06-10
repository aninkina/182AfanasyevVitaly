using System;
namespace Task02
{
    public class ListT <T>
    {
        T[] data;
        public int Length { get; private set; }
        
        public T this[int i]
        {
            get
            {
                return data[i];
            }
            set
            {
                data[i] = value;
            }
        }

        public void Add(T obj)
        {
            Length++;
            if (Length >= data.Length)
                Array.Resize<T>(ref data, data.Length * 2);
            data[Length - 1] = obj;
        }

        public void Remove(int i)
        {
            if (i >= Length)
                throw new IndexOutOfRangeException("Index was out of bounds");
            for (int j = i; j < data.Length - 1; ++j)
            {
                data[j] = data[j + 1];
            }
            Length--;
        }
        
        public ListT()
        {
            data = new T[1];
            Length = 0;
        }
    }
}
