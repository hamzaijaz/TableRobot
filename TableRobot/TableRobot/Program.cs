// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using TableRobot;

class Program
{
    private const string pattern = "^(?i)(PLACE [0-9]+,[0-9]+,(NORTH|EAST|SOUTH|WEST)|MOVE|LEFT|RIGHT|REPORT|HELP|EXIT)$";

    static void Main(string[] args)
    {
        Robot robot = new Robot();
        Table table = new Table(5, 5);

        DisplayInstructions();

        if (TakeAndValidateCommand(robot, table))
        {

        }
    }

    private static bool TakeAndValidateCommand(Robot robot, Table table)
    {
        string userInput = null;
        
        while (!string.Equals("EXIT", userInput, StringComparison.InvariantCultureIgnoreCase))
        {
            userInput = Console.ReadLine();
            if (!Regex.IsMatch(userInput, pattern))
            {
                ShowInvalidInputCommandError();
            }
        }
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