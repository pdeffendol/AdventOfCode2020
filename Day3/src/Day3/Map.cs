using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Map
    {
        private List<string> _mapRows;

        public Map(List<string> rows)
        {
            _mapRows = rows;
        }

        public int Rows => _mapRows.Count;
        public int Columns => _mapRows[0].Length;

        public string GetPosition(int row, int column)
        {
            var realColumn = column % Columns;

            return _mapRows[row][realColumn].ToString();
        }
    }
}
