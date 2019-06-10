using System;
namespace Animals
{
    [Serializable]
    public abstract class Animal : IVocal
    {
        static int numberOfAnimals = 0;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTakenCare { get; set; }
        
        public event Action onSound;
        
        public Animal(string name, bool isTakenCare)
        {
            Id = ++numberOfAnimals;
            Name = name;
            IsTakenCare = isTakenCare;
        }

        public Animal() : this("", false) { }

        public void DoSound()
        {
            onSound?.Invoke();
        }

        public override string ToString()
        {
            return $"Name: {Name}, IsTakenCare: {IsTakenCare}, Id: {Id}";
        }
    }
}
