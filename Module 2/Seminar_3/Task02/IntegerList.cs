using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
    public class IntegerList 
    {
        private static readonly Random Random = new Random();
        
        private int[] _list;
        private int currentElements;
        
        /// <summary>
        /// Создаёт список указанного размера
        /// </summary>
        /// <param name="size">Размер списка</param>
        public IntegerList(int size) 
        {
            _list = new int[size];
            currentElements = 0;
        }

        /// <summary>
        /// Заполняет список числами между 1 и 100 включительно
        /// </summary>
        public void Randomize() 
        {
            for (int i = 0; i < _list.Length; i++)
                _list[i] = Random.Next(101);
            currentElements = _list.Length;
        }
        
        /// <summary>
        /// Печатает элементы списка с их индексами
        /// </summary>
        public void Print() 
        {
            for (int i = 0; i < currentElements; i++)
                Console.WriteLine(i + ":\t" + _list[i]);
        }
        
        /// <summary>
        /// Увеличивает размер списка в 2 раза
        /// </summary>
        private void IncreaseSize()
        {
            Array.Resize(ref _list, _list.Length * 2);
        }
        
        /// <summary>
        /// Добавляет новый элемент в список
        /// </summary>
        /// <param name="newVal">Добавляемый элемент</param>
        public void AddElement(int newVal)
        {
            if (currentElements == _list.Length)
                IncreaseSize();
            _list[currentElements] = newVal;
            currentElements++;
        }
        
        /// <summary>
        /// Удаляет первое вхождение элемента
        /// </summary>
        /// <param name="val">Значение элемента</param>
        public void RemoveFirst(int val)
        {
            int i = Array.FindIndex(_list, x => x == val);
            if (i == -1)
                return;
            for (int j = i; j < currentElements; j++)
            {
                if (j + 1 < _list.Length)
                    _list[j] = _list[j + 1];
                else
                    _list[j] = 0;
            }
            currentElements--;
        }

        /// <summary>
        /// Удаляет все вхождения элемента
        /// </summary>
        /// <param name="val">Значение элемента</param>
        public void RemoveAll(int val)
        {
            int prevSize = currentElements + 1;
            while ((prevSize > currentElements) && (currentElements > 0))
            {
                prevSize = currentElements;
                RemoveFirst(val);
            }
        }
    }
}
