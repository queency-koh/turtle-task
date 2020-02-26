using System;

namespace TurtleTask
{
    /// <summary>
    /// Turtle Class
    /// </summary>
    public class Turtle : ITurtle
    {
        #region PROPERTIES
        /// <summary>
        /// Position (x,y)
        /// </summary>
        public Position Position { get; set;  }

        /// <summary>
        /// Facing Direction
        /// </summary>
        public EDirection Direction { get; set; }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Turtle()
        {
            Position = new Position();
            Direction = EDirection.NONE;
        }

        /// <summary>
        /// Constructor Overload
        /// </summary>
        public Turtle(Position position, EDirection direction)
        {
            Position = position;
            Direction = direction;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Rotate the turtle 90 degrees to the left 
        /// without changing the position of the turtle
        /// </summary>
        public void Left()
        {
            if (Direction == EDirection.NONE)
            {
                return;
            }

            Direction = (EDirection)((int)Direction - 90);

            if (!Enum.IsDefined(typeof(EDirection), Direction))
            {
                Direction = 360 + Direction;
            }
        }

        /// <summary>
        /// Rotate the turtle 90 degrees to the right 
        /// without changing the position of the turtle
        /// </summary>
        public void Right()
        {
            if (Direction == EDirection.NONE)
            {
                return;
            }

            Direction = (EDirection)((int)Direction + 90);

            if (!Enum.IsDefined(typeof(EDirection), Direction))
            {
                Direction = 360 - Direction;
            }
        }

        /// <summary>
        /// Announce the position and direciton of the turtle. 
        /// This can be in any form, but standard output is sufficient
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (Direction == EDirection.NONE)
            {
                return string.Empty;
            }

            return $"{Position.X},{Position.Y},{Direction}";
        }
        #endregion
    }
}
