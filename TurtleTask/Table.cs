using System.Collections.Generic;

namespace TurtleTask
{
    public class Table
    {
        #region MEMBER VARIABLES
        public readonly int Width;
        public readonly int Length;
        #endregion

        #region PROPERTIES
        public List<Position> Map { get; private set; }       
        #endregion

        #region CONSTRUCTOR
        public Table(int width, int length)
        {
            Width = width;
            Length = length;

            CreateMap();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Place the object on the Table
        /// </summary>
        public void Place(ITurtle turtle, Position position, EDirection direction)
        {
            if (!Map.Contains(position))
            {
                return;
            }

            turtle.Position = position;
            turtle.Direction = direction;
        }

        /// <summary>
        /// Move the turtle one unit forward 
        /// in the direction it is currently facing
        /// </summary>
        public void Move(ITurtle turtle)
        {
            if (turtle.Direction == EDirection.NONE)
            {
                return;
            }

            Position position = turtle.Position;

            switch (turtle.Direction)
            {
                case EDirection.NORTH:
                    position.Y += 1;
                    break;
                case EDirection.EAST:
                    position.X += 1;
                    break;
                case EDirection.SOUTH:
                    position.Y -= 1;
                    break;
                case EDirection.WEST:
                    position.X -= 1;
                    break;
                default:
                    break;
            }

            if (Map.Contains(position))
            {
                turtle.Position = position;
            }
        }

        /// <summary>
        /// Create table map
        /// based on Table width and length
        /// </summary>
        private void CreateMap()
        {
            List<Position> positions = new List<Position>();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    positions.Add(new Position(i,j));
                }
            }

            Map = positions;
        }
        #endregion
    }
}
