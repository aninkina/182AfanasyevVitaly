using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 
            В основной программе ввести натуральное число и вычислить суммы
            его цифр, находящихся в чётных и на нечётных разрядах. 
            Разряд единиц считать нулевым и чётным.
            Для этого написать метод с натуральным параметром, вычисляющий
            суммы цифр, находящихся на четных и на нечетных позициях в записи
            значения параметра. 
*/

namespace Task04
{
	delegate bool Comp<T>(T x, T y);

	class Program
	{
		/// <summary>
		/// Inputs and parses the int.
		/// </summary>
		/// <returns>The int.</returns>
		/// <param name="input">Input.</param>
		/// <param name="minValue">Minimum value.</param>
		/// <param name="maxValue">Max value.</param>
		public static int InputInt(string input,
							int minValue, int maxValue,
							Comp<int> CompMin, Comp<int> CompMax)
		{
			Console.WriteLine($"Enter {input} :");
			int result;
			while (!int.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
			{
				Console.WriteLine("Invalid input format! Try again!");
				Console.WriteLine($"Enter {input} :");
			}
			return result;
		}

		public static int InputInt(string input)
		{
			return InputInt(input, int.MinValue, int.MaxValue, (x, y) => x < y, (x, y) => x > y);
		}

		/// <summary>
		/// Inputs and parses the double.
		/// </summary>
		/// <returns>The double.</returns>
		/// <param name="input">Input.</param>
		/// <param name="minValue">Minimum value.</param>
		/// <param name="maxValue">Max value.</param>
		public static double InputDouble(string input,
								  double minValue, double maxValue,
								  Comp<double> compMin, Comp<double> compMax)
		{
			Console.WriteLine($"Enter {input} :");
			double result;
			while (!double.TryParse(Console.ReadLine(), out result) || (compMin(result, minValue)) || (compMax(result, maxValue)))
			{
				Console.WriteLine("Invalid input format! Try again!");
				Console.WriteLine($"Enter {input} :");
			}
			return result;
		}

		public static double InputDouble(string input)
		{
			return InputDouble(input, double.MinValue, double.MaxValue, (x, y) => x < y, (x, y) => x > y);
		}

		/// <summary>
		/// Inputs and parses the char.
		/// </summary>
		/// <returns>The char.</returns>
		public static char InputChar()
		{
			Console.WriteLine("Enter symbol:");
			char c;
			while (!char.TryParse(Console.ReadLine(), out c))
			{
				Console.WriteLine("Invalid input format! Try again!");
				Console.WriteLine("Enter symbol:");
			}
			return c;
		}

		/// <summary>
		/// Inputs and parses the uint.
		/// </summary>
		/// <returns>The uint.</returns>
		/// <param name="input">Input.</param>
		/// <param name="minValue">Minimum value.</param>
		/// <param name="maxValue">Max value.</param>
		public static uint InputUInt(string input,
							uint minValue, uint maxValue,
							Comp<uint> CompMin, Comp<uint> CompMax)
		{
			Console.WriteLine($"Enter {input} :");
			uint result;
			while (!uint.TryParse(Console.ReadLine(), out result) || (result < minValue) || (result > maxValue))
			{
				Console.WriteLine("Invalid input format! Try again!");
				Console.WriteLine($"Enter {input} :");
			}
			return result;
		}

		public static uint InputUInt(string input)
		{
			return InputUInt(input, uint.MinValue, uint.MaxValue, (x, y) => x < y, (x, y) => x > y);
		}

		static void Swap<T>(ref T a, ref T b)
		{
			T tmp = a;
			a = b;
			b = tmp;
		}


		/// <summary>
		/// Finds sum of number's digits on even and odd positions.
		/// </summary>
		/// <param name="number">Number.</param>
		/// <param name="sumEven">Sum on even positions.</param>
		/// <param name="sumOdd">Sum on odd positions.</param>
		static void Sums(uint number, out uint sumEven, out uint sumOdd)
		{
			byte pos = 0;
			sumEven = sumOdd = 0;
			while (number > 0)
			{
				if (pos == 0)
					sumEven += number % 10;
				else
					sumOdd += number % 10;
				pos = (byte)((pos + 1) % 2);
				number /= 10;
			}
		}

		static void Main()
		{
			do
			{
				Console.Clear();

				uint number = InputUInt("positive integer");
				uint sumOdd, sumEven;

				Sums(number, out sumEven, out sumOdd);

				Console.WriteLine($"Sum on odd positions: {sumOdd}\nSum on even positions: {sumEven}");

				Console.WriteLine("Press ESC to exit. Press any other key to continue.");
			} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
		}
	}
}