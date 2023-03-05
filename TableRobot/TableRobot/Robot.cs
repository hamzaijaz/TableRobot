namespace TableRobot
{
    public class Robot
    {
        public enum Directions
        {
            NORTH = 0,
            EAST = 1,
            SOUTH = 2,
            WEST = 3
        };

        private int RobotXCoordinate { get; set; }
        private int RobotYCoordinate { get; set; }
        private int RobotFace { get; set; }

        public Robot()
        {
            RobotXCoordinate = 0;
            RobotYCoordinate = 0;
            RobotFace = 0; //North
        }

        public void RotateRobot(string rotateTowards)
        {
            if (string.Equals("LEFT", rotateTowards, StringComparison.InvariantCultureIgnoreCase))
            {
                RobotFace = RobotFace == ((int)Directions.NORTH) ? ((int)Directions.WEST) : RobotFace - 1;
            }

            if (string.Equals("RIGHT", rotateTowards, StringComparison.InvariantCultureIgnoreCase))
            {
                RobotFace = RobotFace == ((int)Directions.WEST) ? ((int)Directions.NORTH) : RobotFace + 1;
            }
        }

        public void PlaceRobot(int xCoordinate, int yCoordinate, int facing)
        {
            RobotXCoordinate = xCoordinate;
            RobotYCoordinate = yCoordinate;
            RobotFace = facing;
        }

        public void ReportPosition()
        {
            Console.WriteLine($"Current position of robot is: ({RobotXCoordinate}, {RobotYCoordinate}) Facing {Enum.GetName(typeof(Directions), RobotFace)}");
        }

        public void Draw(Table table)
        {
            Console.WriteLine();

            //decrementing i because bottom left corner of table is (0, 0)
            //unlike usual arrays, which have top left corner (0, 0)
            for (int i = table.Rows; i >= 0; i--)
            {
                for (int j = 0; j <= table.Columns; j++)
                {
                    if (j == RobotXCoordinate && i == RobotYCoordinate)
                    {
                        Console.Write("R\t");
                    }
                    else
                    {
                        Console.Write(".\t");
                    }
                }
                Console.WriteLine('\n');
            }
            Console.WriteLine();
        }

        //Move the robot one unit forward in the direction which it is facing
        public void MoveForward(Table table)
        {
            switch (RobotFace)
            {
                case (int)Directions.NORTH:
                    MoveTowardsNorth(table);
                    break;
                case (int)Directions.EAST:
                    MoveTowardsEast(table);
                    break;
                case (int)Directions.SOUTH:
                    MoveTowardsSouth(table);
                    break;
                case (int)Directions.WEST:
                    MoveTowardsWest(table);
                    break;
            }
        }

        private void MoveTowardsNorth(Table table)
        {
            if (RobotYCoordinate + 1 <= table.Rows)
            {
                RobotYCoordinate++;
            }
        }

        private void MoveTowardsEast(Table table)
        {
            if (RobotXCoordinate + 1 <= table.Columns)
            {
                RobotXCoordinate++;
            }

        }

        private void MoveTowardsSouth(Table table)
        {
            if (RobotYCoordinate > 0)
            {
                RobotYCoordinate--;
            }
        }

        private void MoveTowardsWest(Table table)
        {
            if (RobotXCoordinate > 0)
            {
                RobotXCoordinate--;
            }
        }
    }
}
