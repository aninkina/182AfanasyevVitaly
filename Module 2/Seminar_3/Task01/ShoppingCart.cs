using System;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{
    public class ShoppingCart
    { 
        private int _itemCount; // количество предметов в корзине 
        private double _totalPrice; // цена всех предметов в корзине 
        private int _capacity; // текущая вместимость корзины
        Item[] _cart;

        public double TotalPrice { get => _totalPrice; }
        
        /// <summary> 
        /// Создаёт новый экземпляр корзины с вместимостью в 5 элементов
        /// </summary> 
        public ShoppingCart() 
        { 
            _capacity = 5; 
            _itemCount = 0; 
            _totalPrice = 0.0;
            _cart = new Item[_capacity];
        }
        
        /// <summary> 
        /// Добавляет предмет в корзину 
        /// </summary> 
        /// <param name="itemName">Название предмета</param> 
        /// <param name="price">Цена предмета</param>
        /// <param name="quantity">Количество предметов</param> 
        public void AddToCart(string itemName, double price, int quantity) 
        {
            if (_itemCount == _capacity)
                IncreaseSize();
            _itemCount++;
            _cart[_itemCount - 1] = new Item(itemName, price, quantity);
            _totalPrice += price * quantity;
        }
        
        /// <summary> 
        /// Увеличивает вместимость корзины на 3 
        /// </summary> 
        private void IncreaseSize() 
        {
            _capacity += 3;
            Array.Resize(ref _cart, _capacity);
        }

        /// <summary> 
        /// Возвращает предметы в корзине с дополнительной информацией 
        /// </summary> 
        public override string ToString() 
        { 
            string contents = "\nShopping Cart\n";
            contents +="\nItem\t\tUnit Price\tQuantity\tTotal\n";
            for (int i = 0; i < _itemCount; i++) 
                contents += _cart[i] + "\n"; 
            contents += $"\nTotal Price: {_totalPrice:C}\n";
            return contents;
        }
    }
}
