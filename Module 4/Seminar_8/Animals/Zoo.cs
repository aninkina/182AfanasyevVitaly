using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    [Serializable]
    public class Zoo
    {
        List<Animal> animals;
        
        public List<Animal> Animals { get => animals; set => animals = new List<Animal>(value); }

        public Zoo()
        {
            Animals = new List<Animal>();
        }
        
        public Zoo(List<Animal> animals)
        {
            Animals = animals;
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            List<Animal> sortedAnimals = new List<Animal>(Animals);
            return sortedAnimals.OrderBy(x => x.Name.Length).GetEnumerator();
        }
    }
}
