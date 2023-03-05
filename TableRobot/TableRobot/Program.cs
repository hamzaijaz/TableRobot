﻿// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using TableRobot;

class Program
{
    private const int TableXCoordinate = 5;
    private const int TableYCoordinate = 5;

    private const string anyCommandPattern = "^(?i)(PLACE [0-9]+,[0-9]+,(NORTH|EAST|SOUTH|WEST)|MOVE|LEFT|RIGHT|REPORT|HELP|EXIT)$";
    private const string placeOrExitCommandPattern = "^(?i)(PLACE [0-9]+,[0-9]+,(NORTH|EAST|SOUTH|WEST)|HELP|EXIT)$";

    static void Main(string[] args)
    {
        Robot robot = new Robot();
        Table table = new Table(TableXCoordinate, TableYCoordinate);

        DisplayInstructions();

        if (TakeAndValidatePlaceCommand(robot, table))
        {
            DoRobotDrill(robot, table);
        }
    }

    private static void DoRobotDrill(Robot robot, Table table)
    {
        string userInput = null;

        while (!string.Equals("EXIT", userInput, StringComparison.InvariantCultureIgnoreCase))
        {
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "MOVE":
                case "move":
                    robot.MoveForward(table);
                    break;
                case "LEFT":
                case "left":
                    robot.RotateRobot(userInput);
                    break;
                case "RIGHT":
                case "right":
                    robot.RotateRobot(userInput);
                    break;
                case "REPORT":
                case "report":
                    robot.ReportPosition();
                    break;
                case "HELP":
                case "help":
                    DisplayInstructions();
                    break;
                default:
                    TakeAndValidatePlaceCommand(robot, table, userInput);
                    break;
            }
        }
    }

    private static bool TakeAndValidatePlaceCommand(Robot robot, Table table, string userInput1 = null)
    {
        string userInput = string.IsNullOrWhiteSpace(userInput1) ? null : userInput1;
        
        while (!string.Equals("EXIT", userInput, StringComparison.InvariantCultureIgnoreCase))
        {
            userInput = Console.ReadLine();
            if (!Regex.IsMatch(userInput, placeOrExitCommandPattern))
            {
                ShowInvalidInputCommandError();
            }

            else if (userInput.StartsWith("PLACE", StringComparison.InvariantCultureIgnoreCase))
            {
                PlaceRobotOnTable(robot, table, userInput);
                return true;
            }

            else if (userInput.Equals("HELP", StringComparison.InvariantCultureIgnoreCase))
            {
                DisplayInstructions();
            }

            else if (userInput.Equals("REPORT", StringComparison.InvariantCultureIgnoreCase))
            {
                robot.ReportPosition();
            }
        }
        return false;
    }

    private static bool PlaceRobotOnTable(Robot robot, Table table, string userInput)
    {
        string[] placeInformation = userInput.Split(' ')[1].Split(',');
        int userRobotXCoordinate = Int32.Parse(placeInformation[0]);
        int userRobotYCoordinate = Int32.Parse(placeInformation[1]);
        int userRobotDirection = (int)(Enum.Parse(typeof(Robot.Directions), placeInformation[2]));

        if ((userRobotXCoordinate >= 0 && userRobotXCoordinate <= TableXCoordinate)
            && (userRobotYCoordinate >= 0 && userRobotYCoordinate <= TableYCoordinate))
        {
            robot.PlaceRobot(userRobotXCoordinate, userRobotYCoordinate, userRobotDirection);
            return true;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nInvalid coordinates. 0 <= X <= {TableXCoordinate}. 0 <= Y <= {TableYCoordinate}\n");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }

    private static void ShowInvalidInputCommandError() 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCommand validation failed. Please enter a valid input command\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void DisplayInstructions()
    {
        string text =
            "\t\t\t You can use the following commands \n" +
            "\t\t\t-------------------------------\n" +
            "1) PLACE X,Y,F \t: Place Robot on the table at (X,Y) coordinate position, facing F direction.\n\n" +
            "\t\t\t X and Y should be greater than or equal to 0, and less than or equal to 5\n" +
            "\t\t\t F : 'NORTH | EAST | SOUTH | WEST' \n" +
            "\t\t\t (0,0) is SOUTH WEST most corner of the table\n\n" +
            "2) MOVE \t: Move one unit forward in the current direction robot is facing\n" +
            "3) RIGHT \t: Rotate the robot 90 degrees clockwise\n" +
            "4) LEFT \t: Rotate the robot 90 degrees counter clockwise\n" +
            "5) REPORT \t: Report position of robot as X, Y, and F\n" +
            "6) HELP \t: Get list of commands again\n" +
            "7) EXIT \t: Exit the application\n" +
            "--------------------------------------------------------------------------------------------\n";
        Console.WriteLine(text);
    }
}