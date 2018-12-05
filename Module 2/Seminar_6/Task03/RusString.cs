using System;

namespace Task03
{
    public class RusString
    {
        string rusString;

        static Random rnd = new Random();
        
        public RusString(char start, char finish, int n)
        {
            if ((start < 'а') || (finish > 'я'))
                throw new ArgumentException("String must contain only russian letters.");
            if (finish < start)
                throw new ArgumentException("Finish char can't be less than start char.");
            if (n <= 0)
                throw new ArgumentException("Length of string can't be negative.");
            rusString = "";
            for (int i = 0; i < n; ++i)
                rusString += (char)rnd.Next(start, finish + 1);
        }
        
        /// <summary>
        /// Checks if string is a palindrom.
        /// </summary>
        /// <value><c>true</c> if string is palindrom, <c>false</c> otherwise.</value>
        public bool IsPalindrom
        {
            get
            {
                int n = rusString.Length;
                for (int i = 0; i < n / 2; ++i)
                {
                    if (rusString[i] != rusString[n - i - 1])
                        return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Counts number of letter ch in string.
        /// </summary>
        /// <returns>Number of appearances.</returns>
        /// <param name="ch">Letter to find.</param>
        public int CountLetter(char ch)
        {
            int count = 0;
            foreach (char c in rusString)
                if (c == ch)
                    count++;
            return count;
        }

        public override string ToString()
        {
            return rusString;
        }
    }
}
