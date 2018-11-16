using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 6
*/

namespace Task06
{

    class Book
    {
        int _countPages;
        int _sectionNumber;
        
        public int CountPages { get => _countPages; }
        public int SectionNumber { get => _sectionNumber; }

        public Book() : this(0, 0) { }

        public Book(int countPages, int sectionNumber)
        {
            _countPages = countPages;
            _sectionNumber = sectionNumber;
        }

        public override string ToString()
        {
            return $"Pages: {_countPages}, Section: {_sectionNumber}";
        }
    }

    class Library
    {
        Book[] books;
        
        public int BooksCount { get => books.Length; }

        public Library()
        {
            books = new Book[0];
        }

        public Library(Book[] books)
        {
            this.books = (Book[])books.Clone();
        }

        public void AddBook(Book b)
        {
            Array.Resize(ref books, BooksCount + 1);
            books[BooksCount - 1] = b;
        }

        /// <summary>
        /// Counts the books with amount of pages less than N.
        /// </summary>
        /// <returns>Array of books.</returns>
        /// <param name="n">N.</param>
        public Book[] CountBooksWithTheLessAmountOfPages(int n)
        {
            return Array.FindAll(books, x => x.CountPages < n);
        }

        public override string ToString()
        {
            string result = $"{BooksCount} books:";
            foreach (Book b in books)
                result += "\n\t" + b;
            return result;
        }
    }
    
    class Program
    {
    
        /// <summary>
        /// Checks if inputed value meets the conditions.
        /// </summary>
        /// <returns><c>true</c>, if value met the conditions, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static bool CheckConditions<T>(T input, params Func<T, bool>[] conditions)
        {
            foreach (Func<T, bool> condition in conditions)
            {
                if (!condition.Invoke(input))
                    return false;
            }
            return true;
        }
        
        /// <summary>
        /// Inputs and parses the variable of type T.
        /// </summary>
        /// <returns>Variable of type T.</returns>
        /// <param name="input">Input.</param>
        /// <param name="conditions">Conditions.</param>
        static T InputVar<T>(string input, params Func<T, bool>[] conditions)
        {
            var parser = typeof(T).GetMethod("TryParse", new[] { typeof(string), typeof(T).MakeByRefType() });
            if (parser == null)
                throw new ApplicationException($"Invalid type {typeof(T)}");
            Console.WriteLine($"Enter {input}:");
            object[] result = { Console.ReadLine(), null};
            while (!(bool)parser.Invoke(null, result) || !CheckConditions((T)result[1], conditions))
            {
                Console.WriteLine("Invalid input format! Try again!");
                Console.WriteLine($"Enter {input}:");
                result = new object[] { Console.ReadLine(), null };
            }
            return (T)result[1];
        }

        static Random rnd = new Random();
        
        static void Main()
        {
            
            do
            {
                Console.Clear();

                int n = rnd.Next(10, 21);
                Console.WriteLine($"N: {n}");

                Book[] books = new Book[n];
                for (int i = 0; i < n; ++i)
                    books[i] = new Book(rnd.Next(1, 501), rnd.Next(5, 11));
                Library library = new Library(books);

                Console.WriteLine(library);
                
                Book[] booksWithLessPages = library.CountBooksWithTheLessAmountOfPages(200);
                Console.WriteLine($"{booksWithLessPages.Length} books with amount of pages less than 200:");
                foreach (Book b in booksWithLessPages)
                    Console.WriteLine($"\t{b}");
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
