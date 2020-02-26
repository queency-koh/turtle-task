using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleTask.Tests
{
    [TestClass]
    public class TableTests
    {
       [TestMethod]
        public void Given_TableMapIsCreated_When_LengthIs5AndWidthIs5_Then_MapCount25()
        {
            // Arrange
            int expected = 25;

            // Act
            var table = new Table(5, 5);

            // Assert
            int actual = table.Map.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ObjectIsPlace_When_PositionIsValid_Then_ObjectIsPlaced()
        {
            // Arrange
            var expected = new Position(0,1);
            var table = new Table(5,5);
            var turtle = new Turtle();
            var position = new Position(0,1);
            var direction = EDirection.NORTH;

            // Act
            table.Place(turtle, position, direction);

            // Assert
            var actual = turtle.Position;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CommandIsPlace_When_DirectionIsValid_Then_ObjectIsPlaced()
        {
            // Arrange
            var expected = EDirection.NORTH;
            var table = new Table(5, 5);
            var turtle = new Turtle();
            var position = new Position(0, 1);
            var direction = EDirection.NORTH;

            // Act
            table.Place(turtle, position, direction);

            // Assert
            var actual = turtle.Direction;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CommandIsPlace_When_PositionIsInValid_Then_ObjectIsNotPlaced()
        {
            // Arrange
            var expected = new Position();
            var table = new Table(5, 5);
            var turtle = new Turtle();
            var position = new Position(6, 6);
            var direction = EDirection.NORTH;

            // Act
            table.Place(turtle, position, direction);

            // Assert
            var actual = turtle.Position;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CommandIsMove_When_ObjectIsNotYetPlaced_Then_CommandIsIgnored()
        {
            // Arrange
            var expected = new Position();
            var table = new Table(5, 5);
            var position = new Position(0, 0);
            var direction = EDirection.NONE;
            var turtle = new Turtle(position, direction);

            // Act
            table.Move(turtle);

            // Assert
            var actual = turtle.Position;
            Assert.IsTrue(turtle.Direction == EDirection.NONE);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CommandIsMove_When_PositionIsValid_Then_ObjectCanMove()
        {
            // Arrange
            var expected = new Position(0,1);
            var table = new Table(5, 5);
            var position = new Position(0, 0);
            var direction = EDirection.NORTH;
            var turtle = new Turtle(position, direction);
            
            // Act
            table.Move(turtle);

            // Assert
            var actual = turtle.Position;
            Assert.IsTrue(turtle.Direction == EDirection.NORTH);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_CommandIsMove_When_PositionIsInValid_Then_CommandIsIgnored()
        {
            // Arrange
            var expected = new Position(4, 4);
            var table = new Table(5, 5);
            var position = new Position(4, 4);
            var direction = EDirection.NORTH;
            var turtle = new Turtle(position, direction);

            // Act
            table.Move(turtle);

            // Assert
            var actual = turtle.Position;
            Assert.IsTrue(turtle.Direction == EDirection.NORTH);
            Assert.AreEqual(expected, actual);
        }
    }
}