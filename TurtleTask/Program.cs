using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TurtleTask.Utilites;

namespace TurtleTask
{
    public class Program
    {
        static Table table = new Table(5, 5);
        static Turtle turtle = new Turtle();

        public static void Main(string[] args)
        {
            Console.WriteLine("-- Input --");

            while (true)
            {
                // Get Input
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                var inputList = input.Split().Select(i => i.Split(',')).ToList();

                // Check if input is a standard input
                if (Enum.IsDefined(typeof(ECommand), inputList[0][0]))
                {
                    var inputs = ConvertHelper.ToParameter(inputList);
                    Go(inputs.Item1, inputs.Item2, inputs.Item3);
                }

                // Check if input is a file name
                else if (inputList[0][0].IndexOfAny(Path.GetInvalidFileNameChars()) > 0 
                        && File.Exists(inputList[0][0])
                        && Path.GetExtension(inputList[0][0]) == ".txt")
                {
                    // Read File
                    using (StreamReader sr = new StreamReader(inputList[0][0]))
                    {
                        while (!sr.EndOfStream)
                        {
                            var inputLine = sr.ReadLine().Split().Select(i => i.Split(',')).ToList();

                            Console.WriteLine(inputLine[0][0]);

                            var inputs = ConvertHelper.ToParameter(inputLine);
                            Go(inputs.Item1, inputs.Item2, inputs.Item3);
                        }
                    }
                }
            }
         }

        public static void Go(ECommand command, Position position, EDirection direction)
        {
            switch (command)
            {
                case ECommand.PLACE:
                    table.Place(turtle, position, direction);
                    break;
                case ECommand.MOVE:
                    table.Move(turtle);
                    break;
                case ECommand.LEFT:
                    turtle.Left();
                    break;
                case ECommand.RIGHT:
                    turtle.Right();
                    break;
                case ECommand.REPORT:
                    var output = turtle.Report();

                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine($"\n-- OUTPUT --\n {output} \n \n -- INPUT --");
                    }

                    break;
                default:
                    Console.WriteLine($"{command} is not a valid Command.");
                    break;
            }
        }
    }
}

