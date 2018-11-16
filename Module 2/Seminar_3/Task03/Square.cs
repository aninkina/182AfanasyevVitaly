using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 3
*/

namespace Task03
{
    public class Square
    {
        private int[][] _square;
        
        /// <summary> 
        /// Создаёт новый квадрат указанного размера 
        /// </summary> 
        /// <param name="size">Размер квадрата</param>
        public Square(int size) 
        {
            _square = new int[size][];
            for (int i = 0; i < size; ++i)
                _square[i] = new int[size];
        }
        
        /// <summary> 
        /// Возвращает сумму элементов указанной строки 
        /// </summary> 
        /// <param name="row">Номер строки</param>
        public int SumRow(int row) 
        {
            int sum = 0;
            for (int i = 0; i < _square.Length; ++i)
                sum += _square[row][i];
            return sum;
        }
        
        /// <summary> 
        /// Возвращает сумму элементов указанного столбца 
        /// </summary> 
        /// <param name="col">Номер столбца</param>
        public int SumCol(int col) 
        { 
            int sum = 0;
            for (int i = 0; i < _square.Length; ++i)
                sum += _square[i][col];
            return sum;
        }
        
        /// <summary>
        /// Возвращает сумму элементов главной диагонали
        /// </summary>
        public int SumMainDiag() 
        { 
            int sum = 0;
            for (int i = 0; i < _square.Length; ++i)
                sum += _square[i][i];
            return sum;
        }
        
        /// <summary>
        /// Возвращает сумму элементов побочной диагонали
        /// </summary>
        public int SumOtherDiag() 
        { 
            int sum = 0;
            for (int i = 0; i < _square.Length; ++i)
                sum += _square[i][_square.Length - i - 1];
            return sum;
        }
        
        /// <summary>
        /// Возвращает, является ли текущий квадрат магическим
        /// </summary>
        public bool Magic() 
        {
            int sum = SumMainDiag();
            if (sum != SumOtherDiag())
                return false;
            for (int i = 0; i < _square.Length; ++i)
            {
                if (sum != SumRow(i))
                    return false;
                if (sum != SumCol(i))
                    return false;
            }
            return true;
        }
        
        /// <summary>
        /// Считывает значения элементов квадрата из консоли
        /// </summary>
        public void ReadSquare(string[] lines, int lineIndex)
        {
            for (int row = 0; row < _square.Length; row++)
            {
                string[] line = lines[lineIndex + row].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Length != _square.Length)
                    Console.WriteLine($"Ошибка при чтении квадрата: строка должна содержать { _square.Length} значений, а содержит { line.Length}");
                for (int i = 0; i < _square.Length; i++)
                    int.TryParse(line[i], out _square[row][i]);
            }
        }
        
        /// <summary>
        /// Выводит аккуратно отформатированное содержимое квадрата
        /// </summary>
        public void PrintSquare()
        {
            for (int i = 0; i < _square.Length; ++i)
            {
                for (int j = 0; j < _square.Length; ++j)
                {
                    Console.Write(_square[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}