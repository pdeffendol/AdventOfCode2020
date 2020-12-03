using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class MapWalker
    {
        private readonly Map _map;

        private int _currentRow = 0;
        private int _currentColumn = 0;

        private const string Tree = "#";

        public MapWalker(Map map, int right, int down)
        {
            _map = map;
            StepsRight = right;
            StepsDown = down;
        }

        public int StepsRight { get; private set; }
        public int StepsDown { get; private set; }

        public IEnumerable<string> GetPositions()
        {
            _currentColumn = 0;
            _currentRow = 0;
            while (_currentRow < _map.Rows)
            {
                yield return _map.GetPosition(_currentRow, _currentColumn);
                _currentRow += StepsDown;
                _currentColumn += StepsRight;
            }
        }

        public int CountTrees()
        {
            return GetPositions().Count(p => p == Tree);
        }
    }
}
