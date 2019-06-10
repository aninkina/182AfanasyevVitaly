﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static Checker.InputChecker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 2
*/

namespace Task02
{
    class Program
    {
        static Random rnd = new Random();
        
        static string RandomName(int length)
        {
            string name = "";
            for (; length > 0; --length)
                name = name + (char)('a' + rnd.Next(0, 26));
            return name;
        }

        static List<Human> CreateProfessors(int professorsNumber)
        {
            List<Human> professors = new List<Human>();
            for (int i = 0; i < professorsNumber; ++i)
                professors.Add(new Professor(RandomName(rnd.Next(5, 11))));
            return professors;
        }
        
        static void Main()
        {
            string fileName = "task2";
            do
            {
                Console.Clear();

                Department[] departments = new Department[2];
                departments[0] = new Department(RandomName(rnd.Next(5, 11)), CreateProfessors(rnd.Next(5, 11)));
                departments[1] = new Department(RandomName(rnd.Next(5, 11)), CreateProfessors(rnd.Next(5, 11)));
                
                Console.WriteLine("Objects:");
                Console.WriteLine("\t" + departments[0]);
                Console.WriteLine("\t" + departments[1]);
                Console.WriteLine();
                
                #region JSONSerialization

                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Department[]), new Type[] { typeof(Professor)});
                using (FileStream fs = new FileStream(fileName + ".json", FileMode.Create))
                {
                    formatter.WriteObject(fs, departments);
                    Console.WriteLine("Successful JSON-serialization");
                }
                Console.WriteLine();

                Department[] departmentsDeserialized = null;

                using (FileStream fs = new FileStream(fileName + ".json", FileMode.Open))
                {
                    departmentsDeserialized = (Department[])formatter.ReadObject(fs);
                    Console.WriteLine("Successful JSON-deserialization");
                }
                Console.WriteLine("Deserialized objects:");
                Console.WriteLine("\t" + departmentsDeserialized[0]);
                Console.WriteLine("\t" + departmentsDeserialized[1]);
                Console.WriteLine();

                #endregion JSONSerialization
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}