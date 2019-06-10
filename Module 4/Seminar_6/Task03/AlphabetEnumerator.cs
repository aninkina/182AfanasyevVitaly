using System;
using System.Collections;

namespace Task03
{
    public class AlphabetEnumerator : IEnumerator
    {
        char beginLetter;
        int length;
        int position = -1;
        
        public AlphabetEnumerator(char beginLetter, int length)
        {
            this.beginLetter = beginLetter;
            this.length = length;
        }

        public object Current
        {
            get
            {
                if ((position < 0) || (position >= length))
                {
                    throw new InvalidOperationException();
                }
                return (char)(beginLetter + position);
            }
        }

        public bool MoveNext()
        {
            if (position < length - 2)
            {
                position += 2;
                return true;
            }
            if (position == length - 1 - (length % 2))
            {
                position = 0;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
