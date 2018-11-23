using System;

namespace Task05
{
    abstract public class UnitsBase {
        protected int unit_code; // номер единицы
        protected double price; // цена за единицу
        protected string name; // название
        
        public int UnitCode { get => unit_code; protected set => unit_code = value; }
        public double Price { get => price; protected set => price = value; }
        public string Name { get => name; protected set => name = value; }

        protected UnitsBase(int unit_code, double price, string name)
        {
            UnitCode = unit_code;
            Price = price;
            Name = name;
        }
        
        public virtual double Discount(int percentage)
        {
            return price * (100 - percentage) / 100;
        }
        
        public override string ToString()
        {
            return $"Unit: Name: {Name}, Unit code: {UnitCode}";
        }
    }
}
