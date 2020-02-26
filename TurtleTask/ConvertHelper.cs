using System;
using System.Collections.Generic;

namespace TurtleTask.Utilites
{
    /// <summary>
    /// Convert Helper Class
    /// </summary>
    public static class ConvertHelper
    {
        /// <summary>
        /// Convert Inputs into Command, Position, Direction
        /// </summary>
        public static Tuple<ECommand, Position, EDirection> ToParameter(List<string[]> input)
        {
            var command = ConvertHelper.ToCommand(input[0][0]);
            var position = new Position();
            var direction = EDirection.NONE;

            if (input.Count > 1 && input[1].Length == 3)
            {
                position = ConvertHelper.ToPosition(input[1][0], input[1][1]);
                direction = ConvertHelper.ToDirection(input[1][2]);
            }

            return new Tuple<ECommand, Position, EDirection>(command, position, direction);
        }

        /// <summary>
        /// Convert string to Command
        /// </summary>
        public static ECommand ToCommand(string input)
        {
           return (ECommand)Enum.Parse(typeof(ECommand), input);
        }

        /// <summary>
        /// Convert string 1,2 to Position
        /// </summary>
        public static Position ToPosition(string position1, string position2)
        {
            int x = Convert.ToInt32(position1);
            int y = Convert.ToInt32(position2);

            return new Position(x, y);
        }

        /// <summary>
        /// Convert string to EDirection
        /// </summary>
        public static EDirection ToDirection(string input)
        {
            return (EDirection)Enum.Parse(typeof(EDirection), input);
        }
    }
}
