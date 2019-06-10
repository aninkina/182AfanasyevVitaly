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
   Задача: 1
*/

namespace Task01
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

        static Group CreateGroup(string groupName, int studentsNumber)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsNumber; ++i)
                students.Add(new Student(RandomName(rnd.Next(5, 11)), rnd.Next(1, 7)));
            Group group = new Group(groupName, students);
            return group;
        }
        
        static void Main()
        {
            string fileName = "task1";
            do
            {
                Console.Clear();

                Group[] groups = new Group[2];
                groups[0] = CreateGroup("First group", rnd.Next(5, 31));
                groups[1] = CreateGroup("Second group", rnd.Next(5, 31));
                Console.WriteLine("Objects:");
                Console.WriteLine("\t" + groups[0]);
                Console.WriteLine("\t" + groups[1]);
                Console.WriteLine();

                #region JSONSerialization

                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Group[]));
                using (FileStream fs = new FileStream(fileName + ".json", FileMode.Create))
                {
                    formatter.WriteObject(fs, groups);
                    Console.WriteLine("Successful JSON-serialization");
                }
                Console.WriteLine();

                Group[] groupsDeserialized = null;

                using (FileStream fs = new FileStream(fileName + ".json", FileMode.Open))
                {
                    groupsDeserialized = (Group[])formatter.ReadObject(fs);
                    Console.WriteLine("Successful JSON-deserialization");
                }
                Console.WriteLine("Deserialized objects:");
                Console.WriteLine("\t" + groupsDeserialized[0]);
                Console.WriteLine("\t" + groupsDeserialized[1]);
                Console.WriteLine();

                #endregion JSONSerialization
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}