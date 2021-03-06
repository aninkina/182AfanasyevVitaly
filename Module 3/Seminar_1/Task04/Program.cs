﻿using System;
using System.Collections.Generic;
using System.Linq;
using Checker;

/*
   Дисциплина: "Программирование"
   Группа: БПИ182_1
   Студент: Афанасьев Виталий Олегович
   Задача: 4
*/

namespace Task04
{
    class Program
    {
        /// <summary>
        /// Marks the path of the robot on the field. Throws an ArgumentException if the robot is out of bounds.
        /// </summary>
        public static void MarkPosition(object sender, EventArgs args)
        {
            if (robot.X < 0 || robot.X >= field.GetLength(1) || robot.Y < 0 || robot.Y >= field.GetLength(0))
                throw new ArgumentException("Robot is out of bounds.");
            field[robot.Y, robot.X] = '+';
        }
        
        static Robot robot = new Robot();
        static char[,] field;
        
        static void Main()
        {
            Action movement = null;
            const string allowedCommands = "RLFB";
            robot.PositionChanged += MarkPosition;
            Console.ResetColor();
            
            do
            {
                Console.Clear();

                movement = null;
                robot.Reset();

                int width = InputChecker.InputVar<int>("width of field (1 - 20)", x => (x > 0) && (x <= 20));
                int height = InputChecker.InputVar<int>("height of field (1 - 20)", x => (x > 0) && (x <= 20));
                field = new char[height, width];
                for (int i = 0; i < height; ++i)
                    for (int j = 0; j < width; ++j)
                        field[i, j] = '-';
                field[0, 0] = '+';
                
                Console.WriteLine(robot.Position());
                Console.Write("Enter commands (string of R, L, F and B): "); 
                string commands = Console.ReadLine();
                while (commands == null || !commands.All(allowedCommands.Contains))
                {
                    Console.WriteLine("Invalid input format! Try again!");
                    Console.Write($"Enter commands (string of R, L, F and B): ");
                    commands = Console.ReadLine();
                }

                bool outOfRange = false;

                foreach (char c in commands)
                {
                    switch (c)
                    {
                        case 'R':
                            movement += robot.Right;
                            break;
                        case 'L':
                            movement += robot.Left;
                            break;
                        case 'F':
                            movement += robot.Forward;
                            break;
                        case 'B':
                            movement += robot.Backward;
                            break;
                        default:
                            throw new ArgumentException("Invalid commands.");
                    }
                }
                
                try
                {
                    movement?.Invoke();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    outOfRange = true;
                }
                if (!outOfRange)
                {
                    field[robot.Y, robot.X] = '*';
                    for (int i = 0; i < height; ++i)
                    {
                        for (int j = 0; j < width; ++j)
                        {
                            switch (field[i, j])
                            {
                                case '+':
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                case '*':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                default:
                                    Console.ResetColor();
                                    break;
                            }
                            
                            Console.Write(field[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.ResetColor();
                    Console.WriteLine(robot.Position());
                }
                
                
                Console.WriteLine("Press Esc to exit. Press any other key to continue.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}