using System;

namespace Task05
{
    public class Cards : UnitsBase {
        private string message; // сообщение
        
        public string Message { get => message; private set => message = value; }
        
        public Cards(int unit_code, double price, string name, 
                string message) : base(unit_code, price, name)
        {
            Message = message;
        }
        
        public override string ToString()
        {
            return $"Card: Name: {Name}, Unit code: {UnitCode}, Message: {Message}";
        }
    }
}
