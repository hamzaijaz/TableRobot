using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableRobot
{
    public class Table
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Table(int rows, int cols) 
        {
            Rows = rows;
            Columns = cols;
        }

        public bool IsValidPosition(int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate <= Rows
                && yCoordinate >= 0 && yCoordinate <= Columns;
        }
    }
}
