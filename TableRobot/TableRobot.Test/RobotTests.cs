using FluentAssertions;

namespace TableRobot.Test
{
    [Collection("Tests")] // XUnit Requirement
    public class RobotTests
    {
        [Fact]
        public void Robot_MoveForwardTwiceNorth_ShouldIncreaseYPositionByTwoUnits()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default
            var table = new Table(5, 5);
            

            // Act
            robot.MoveForward(table);
            robot.MoveForward(table);

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (0, 2) Facing NORTH");
        }

        [Fact]
        public void Given_CurrentFaceOfRobotIsNorth_RotateLeft_ShouldRotateRobot_CounterClockwise()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default

            // Act
            robot.Rotate("LEFT"); //WEST

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (0, 0) Facing WEST");
        }

        [Fact]
        public void Given_CurrentFaceOfRobotIsNorth_RotateLeftTwice_ShouldRotateRobot_CounterClockwiseTwice()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default

            // Act
            robot.Rotate("LEFT"); //WEST
            robot.Rotate("LEFT"); //SOUTH

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (0, 0) Facing SOUTH");
        }

        [Fact]
        public void Given_CurrentFaceOfRobotIsNorth_RotateRight_ShouldRotateRobot_Clockwise()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default

            // Act
            robot.Rotate("RIGHT"); //EAST

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (0, 0) Facing EAST");
        }

        [Fact]
        public void Given_CurrentFaceOfRobotIsNorth_RotateRightTwice_ShouldRotateRobot_ClockwiseTwice()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default

            // Act
            robot.Rotate("RIGHT"); //EAST
            robot.Rotate("RIGHT"); //SOUTH

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (0, 0) Facing SOUTH");
        }

        [Fact]
        public void Given_RobotIsAtEdgeOfTable_MoveForward_Should_KeepRobotFromFallingOffTable()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default
            robot.Place(5, 5, 0); //x = 5, y = 5, North
            var table = new Table(5, 5);

            // Act
            for (int i = 0; i < 10; i++)
            {
                robot.MoveForward(table);
            }

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (5, 5) Facing NORTH");
        }

        [Fact]
        public void Given_RobotIsAtEdgeOfTable_MoveSouthMoreThanTableSize_ShouldKeepRobotFromFallingOffTable_AndBringAtZeroUnitVertically()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default
            robot.Place(5, 5, 2); //x = 5, y = 5, Facing South
            var table = new Table(5, 5);

            // Act
            for (int i = 0; i < 10; i++)
            {
                robot.MoveForward(table);
            }

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (5, 0) Facing SOUTH");
        }

        [Fact]
        public void Given_RobotIsAtEdgeOfTable_MoveSouthOnce_ShouldBringRobotOneUnitDown()
        {
            // Arrange
            var robot = new Robot(); //x = 0, y = 0, Face = North be default
            robot.Place(5, 5, 2); //x = 5, y = 5, Facing South
            var table = new Table(5, 5);

            // Act
            robot.MoveForward(table);
            robot.MoveForward(table);

            // Assert
            var report = robot.ReportPosition();
            report.Should().Be("Current position of robot is: (5, 3) Facing SOUTH");
        }
    }
}