using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        public Cell[][] Cells { get; set; }
        private List<Cell> _resurrectedCells;
        public IEnumerable<Cell> ResurrectedCells
        {
            get { return _resurrectedCells; }            
        }

        public World() : this(0, 0) { }

        public World(int xExtent, int yExtent)
        {
            // todo: if((xExtent != 0 && yExtent == 0) || (xExtent == 0 && yExtent != 0)) throw exception
            // todo: if x && y < 3 && != 0 throw
            Cells = CreateWorld(xExtent, yExtent);
            _resurrectedCells = new List<Cell>();
        }

        private Cell[][] CreateWorld(int xExtent, int yExtent)
        {
            var cells = new Cell[xExtent][];
            for (var i = 0; i < xExtent; i++)
            {
                cells[i] = new Cell[yExtent];
            }
            return cells;
        }

        public void AddCells(params Cell[] cells)
        {
            foreach (Cell cell in cells)
            {
                Cells[cell.X][cell.Y] = cell;
            }
        }

        public int CellsCount
        {
            get
            {
                return Cells.Sum(t => t.Count(t1 => t1 != null));
            }
        }

        public void Tick()
        {
            for (int x = 0; x < Cells.Length; x++)
            {
                for (int y = 0; y < Cells[x].Length; y++)
                {
                    Cell[][] localWorld = BuildLocalWorld(x, y);
                    RunRules(localWorld, x, y);
                }
            }
            CopyWorld();
        }

        private void CopyWorld()
        {
            if (Cells.Length > 0)
            {
                Cell[][] newWorld = CreateWorld(Cells.Length, Cells[0].Length);

                UpdateWorld(newWorld);
                Cells = newWorld;
            }
            foreach (Cell resurrectedCell in ResurrectedCells)
            {
                Cells[resurrectedCell.X][resurrectedCell.Y] = resurrectedCell;
            }
        }

        private void UpdateWorld(Cell[][] newWorld)
        {
            for (int x = 0; x < Cells.Length; x++)
            {
                for (int y = 0; y < Cells[x].Length; y++)
                {
                    Cell cell = Cells[x][y];
                    if (cell != null && cell.IsAlive)
                    {
                        newWorld[x][y] = cell;
                    }
                }
            }
        }

        private void RunRules(Cell[][] localWorld, int x, int y)
        {
            if (IsDead(localWorld) && localWorld[1][1] != null)
            {
                localWorld[1][1].IsAlive = false;
            }
            if (IsResurrected(localWorld))
            {
                _resurrectedCells.Add(new Cell(x, y));
            }
        }

        private bool IsResurrected(Cell[][] localWorld)
        {
            int count = 0;
            foreach (Cell[] cells in localWorld)
            {
                foreach (Cell cell in cells)
                {
                    if (cell != null)
                    {
                        count++;
                    }
                }
            }
            return count == 3;
        }

        private bool IsDead(Cell[][] localWorld)
        {
            int count = 0;
            foreach (Cell[] cells in localWorld)
            {
                foreach (Cell cell in cells)
                {
                    if (cell != null)
                    {
                        count++;
                    }
                }
            }
            return count < 3 || count > 4;
        }

        private Cell[][] BuildLocalWorld(int xCell, int yCell)
        {
            Cell[][] localWorld = new Cell[3][];
            for (int i = 0; i < 3; i++)
            {
                localWorld[i] = new Cell[3];
            }
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Cell c = GetCellRelativeTo(xCell, yCell, x, y);
                    localWorld[x + 1][y + 1] = c;
                }
            }
            return localWorld;
        }

        private Cell GetCellRelativeTo(int xCell, int yCell, int x, int y)
        {
            int xCoOrd = x;
            int yCoOrd = y;
            NormalizeCoOrdinates(xCell, yCell, ref xCoOrd, ref yCoOrd);
            return Cells[xCoOrd][yCoOrd];
        }

        private void NormalizeCoOrdinates(int xCell, int yCell, ref int xCoOrd, ref int yCoOrd)
        {
            xCoOrd = xCell + xCoOrd;

            if (xCoOrd < 0)
            {
                xCoOrd = xCoOrd + Cells.Length;
            }
            else if (xCoOrd >= Cells.Length)
            {
                xCoOrd = xCoOrd - Cells.Length;
            }

            yCoOrd = yCell + yCoOrd;
            if (yCoOrd < 0)
            {
                yCoOrd = yCoOrd + Cells[0].Length;
            }
            else if (yCoOrd >= Cells[0].Length)
            {
                yCoOrd = yCoOrd - Cells[0].Length;
            }
        }
    }
}