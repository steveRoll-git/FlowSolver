using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSolver
{
    static class Solver
    {
        public static Position[][] Solve(Level level)
        {
            // a lookup of which cells were "filled", points that touch them are touching an edge
            bool[,] filledCells = new bool[level.width, level.height];

            // contains points where both ends are touching an edge
            IEnumerable<PointDef> edgePoints;

            bool TouchesEdge(Position position)
            {
                return position.x == 0
                    || position.x == level.width - 1
                    || position.y == 0
                    || position.y == level.height - 1
                    || filledCells[position.x - 1, position.y]
                    || filledCells[position.x + 1, position.y]
                    || filledCells[position.x, position.y + 1]
                    || filledCells[position.x, position.y - 1];
            }

            void UpdateEdgePoints()
            {
                edgePoints = from PointDef def in level.points
                             where TouchesEdge(def.p1) || TouchesEdge(def.p2)
                             select def;
            }

            UpdateEdgePoints();
        }
    }
}
