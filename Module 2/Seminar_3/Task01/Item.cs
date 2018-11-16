﻿using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{
    public class Item
    {
        /// <summary> 
        /// Название предмета 
        /// </summary> 
        public string Name { get; }
        
        /// <summary> 
        /// Цена предмета 
        /// </summary> 
        public double Price { get; }

        /// <summary> 
        /// Количество предметов 
        /// </summary> 
        public int Quantity { get; }
        
        /// <summary> 
        /// Создаёт новый предмет на основе переданных свойств 
        /// </summary> 
        /// <param name="itemName">Название предмета</param> 
        /// <param name="itemPrice">Цена предмета</param>
        /// <param name = "numPurchased" > Количество предметов</param>
        public Item(string itemName, double itemPrice, int numPurchased)
        {
            Name = itemName;
            Price = itemPrice; 
            Quantity = numPurchased;
        }
        
        /// <summary> 
        /// Возвращает строку, представляющую текущий объект 
        /// </summary> 
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}\t\t{Price:C}\t\t{Quantity}\t\t{Price * Quantity:C}";
        }
    }
}
