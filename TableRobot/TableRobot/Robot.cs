using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void PlaceRobot(int xCoordinate, int yCoordinate, int facing)
        {
            RobotXCoordinate = xCoordinate;
            RobotYCoordinate = yCoordinate;
            RobotFace = facing;
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
            if (RobotYCoordinate + 1 < table.Rows)
            {
                RobotYCoordinate++;
            }
        }

        private void MoveTowardsEast(Table table)
        {
            if (RobotXCoordinate + 1 < table.Columns)
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
