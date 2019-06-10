using System;
using System.Collections;

namespace Task03
{
    public class Alphabet
    {
        public char BeginLetter { get; set; }
        public int Length { get; set; }
        
        public Alphabet(char beginLetter, int length)
        {
            BeginLetter = beginLetter;
            Length = length;
        }

        public IEnumerator GetEnumerator()
        {
            return new AlphabetEnumerator(BeginLetter, Length);
        }
    }
}
