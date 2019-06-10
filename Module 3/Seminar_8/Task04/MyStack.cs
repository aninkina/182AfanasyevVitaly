using System;

namespace Task04
{
    public class MyStack<T>
    {
        T[] items;
        public int Size { get; private set; }
        
        public MyStack()
        {
            items = new T[1];
            Size = 0;
        }

        public void Push(T item)
        {
            if (Size >= items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[Size++] = item;
        }

        public T Pop()
        {
            if (Size == 0)
                throw new ApplicationException("Stack is empty.");
            return items[Size--];
        }
    }
}
