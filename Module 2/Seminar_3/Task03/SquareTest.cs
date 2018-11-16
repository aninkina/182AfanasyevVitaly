using System;
using System.IO;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3
*/

namespace Task03
{
    class SquareTest
    {
        static void Main(string[] args) 
        {
            string[] lines = File.ReadAllLines(@"../../magicData.txt"); // читаем все строки файла в массив
            int lineIndex = 0; // на какой строке файла находимся
            int count = 0; // считаем, на каком мы сейчас квадрате
            while (lines.Length > lineIndex) 
            {
                int size; // размер квадрата
                if (!int.TryParse(lines[lineIndex], out size)) 
                {
                    Console.WriteLine($"Ошибка при чтении размера квадрата: {lines[lineIndex]} - не число (строка {lineIndex+1})");
                    return;
                }
                if (size == -1) // в конце файла ожидается -1
                    return;
                lineIndex++;
                Square square = new Square(size);
                square.ReadSquare(lines, lineIndex);
                Console.WriteLine($"\n******** Квадрат номер {++count} ********");
                square.PrintSquare();
                Console.WriteLine("Сумма в строках:");
                for (int i = 0; i < size; ++i)
                    Console.WriteLine($"\tСумма в {i + 1} строке: {square.SumRow(i)}");
                Console.WriteLine("Сумма в столбцах:");
                for (int i = 0; i < size; ++i)
                    Console.WriteLine($"\tСумма в {i + 1} столбце: {square.SumCol(i)}");
                Console.WriteLine($"Сумма на главной диагонали: {square.SumMainDiag()}");
                Console.WriteLine($"Сумма на побочной диагонали: {square.SumOtherDiag()}");
                Console.WriteLine("Квадрат" + (square.Magic() ? " " : " не ") + "является магическим");
                lineIndex += size;
            }
        }
    }
}
