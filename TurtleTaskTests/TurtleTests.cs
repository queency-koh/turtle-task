using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTask.Tests
{
    [TestClass()]
    public class TurtleTests
    {
        [TestMethod()]
        public void Given_CommandIsLeft_When_TurtleIsPlaced_Then_TurtleRotate90Degrees()
        {
            // Arrange
            var expected = EDirection.WEST;
            var table = new Table(5, 5);
            var turtle = new Turtle();
            var position = new Position(0, 0);
            var direction = EDirection.NORTH;

            // Act
            table.Place(turtle, position, direction);
            turtle.Left();

            // Assert
            var actual = turtle.Direction;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Given_CommandIsLeft_When_TurtleIsNotPlaced_Then_CommandIsIgnored()
        {
            // Arrange
            var turtle = new Turtle();
           
            turtle.Left();

            // Assert
            Assert.IsTrue(turtle.Direction == EDirection.NONE);
        }

        [TestMethod()]
        public void Given_CommandIsRight_When_TurtleIsPlaced_Then_TurtleRotate90Degrees()
        {
            // Arrange
            var expected = EDirection.EAST;
            var table = new Table(5, 5);
            var turtle = new Turtle();
            var position = new Position(0, 0);
            var direction = EDirection.NORTH;

            // Act
            table.Place(turtle, position, direction);
            turtle.Right();

            // Assert
            var actual = turtle.Direction;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Given_CommandIsRight_When_TurtleIsNotPlaced_Then_CommandIsIgnored()
        {
            // Arrange
            var turtle = new Turtle();

            // Act
            turtle.Right();

            // Assert
            Assert.IsTrue(turtle.Direction == EDirection.NONE);
        }

        [TestMethod()]
        public void Given_CommandIsReport_When_PositionIsValid_Then_AnnounceYXF()
        {
            // Arrange
            const string expected = "0,1,SOUTH";
            var table = new Table(5, 5);
            var turtle = new Turtle();
            var position = new Position(0, 1);
            var direction = EDirection.SOUTH;

            // Act
            table.Place(turtle, position, direction);

            // Assert
            var actual = turtle.Report();
            Assert.AreEqual(expected, actual);
        }
    }
}