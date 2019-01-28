using System;

namespace Task02
{
    public class Car 
    {
        private CarEngineHandler listOfHandlers;
        
        // Информация о внутреннем состоянии
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        
        // Машина работоспособна?
        private bool carIsDead;
        
        // Конструкторы
        public Car() { MaxSpeed = 100; }
        
        public Car(string name, int maxSp, int currSp) 
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
                listOfHandlers?.Invoke("Car is dead");
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    listOfHandlers?.Invoke("Car is dead");
                }
                else
                    listOfHandlers?.Invoke($"Speed: {CurrentSpeed}");
            }
        }
    } 
}
