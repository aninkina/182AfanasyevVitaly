﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Collections;
using static Checker.InputChecker;
using Animals;
using System.Xml.Serialization;
using System.Linq;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 1
*/

namespace Task01
{   
    class Program
    {
        static Random rnd = new Random();

        public static string RandomName(int length)
        {
            string name = "";
            for (int i = 0; i < length; ++i)
                name += (char)rnd.Next('a', 'z');
            return name;
        }
        
        static void Main()
        {
            int minAnimals = 1, maxAnimals = 100;
            do
            {
                Console.Clear();

                int n = InputVar<int>($"number of animals ({minAnimals} - {maxAnimals})", x => (x >= minAnimals) && (x <= maxAnimals));

                List<Animal> animals = new List<Animal>();
                for (int i = 0; i < n; ++i)
                {
                    bool wasGenerated = false;
                    while (!wasGenerated)
                    {
                        try
                        {
                            if (rnd.Next(2) == 0)
                            {
                                animals.Add(new Mammal(RandomName(rnd.Next(4, 11)), rnd.Next(10) < 4, rnd.Next(-10, 120)));
                                animals.Last().onSound += delegate ()
                                {
                                    Console.WriteLine("я млекопитающее, би-би-би");
                                };
                            }
                            else
                            {
                                animals.Add(new Bird(RandomName(rnd.Next(4, 11)), rnd.Next(10) < 4, rnd.Next(-10, 120)));
                                animals.Last().onSound += delegate ()
                                {
                                    Console.WriteLine("я птичка, пип-пип-пип");
                                };
                            }
                            wasGenerated = true;
                        }
                        catch (ArgumentException)
                        {
                            wasGenerated = false;
                        }
                    }
                }
                
                Zoo zoo = new Zoo(animals);

                foreach (var i in zoo)
                {
                    Console.WriteLine(i);
                    i.DoSound();
                }

                XmlSerializer serializer = new XmlSerializer(typeof(Zoo), new Type[]{ typeof(Mammal), typeof(Bird) });
                using (var file = new FileStream("zooAnimal.ser", FileMode.Create))
                {
                    serializer.Serialize(file, zoo);
                }

                Zoo newZoo = new Zoo();
                using (var file = new FileStream("zooAnimal.ser", FileMode.Open))
                {
                    newZoo = (Zoo)serializer.Deserialize(file);
                }
                
                Console.WriteLine("\nNew zoo:");
                foreach (var i in newZoo)
                {
                    Console.WriteLine(i);
                }
                
                var birdsNewZoo = new Zoo(newZoo.Animals.Where(x => (x.GetType() == typeof(Bird)) && x.IsTakenCare).ToList());
                Console.WriteLine("\nBirds of the new zoo with IsTakenCare == True:");
                foreach (var i in birdsNewZoo)
                {
                    Console.WriteLine(i);
                }
                
                var mammalsNewZoo = new Zoo(newZoo.Animals.Where(x => (x.GetType() == typeof(Mammal)) && !x.IsTakenCare).ToList());
                Console.WriteLine("\nMammals of the new zoo with IsTakenCare == False:");
                foreach (var i in mammalsNewZoo)
                {
                    Console.WriteLine(i);
                }
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}