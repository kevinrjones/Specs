using System.Linq;
using GameOfLife;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GameOfLifeSpecs
{
    [Binding]
    public class GameOfLifeCellSteps
    {
        [Given(@"I have a cell with (.*) adjacent cells")]
        public void GivenIHaveACellWith4AdjacentCells(int numberOfAdjacentCells)
        {
            World world = new World(9, 9);
            ScenarioContext.Current["world"] = world;
            switch (numberOfAdjacentCells)
            {
                case 1:
                    world.AddCells(new Cell(4, 5), new Cell(4, 4));
                    break;
                case 2:
                    world.AddCells(new Cell(4, 5), new Cell(4, 4), new Cell(4, 6));
                    break;
                case 3:
                    world.AddCells(new Cell(4, 5), new Cell(4, 4), new Cell(4, 6), new Cell(3, 5));
                    break;
                case 4:
                    world.AddCells(new Cell(4, 5), new Cell(4, 4), new Cell(4, 6), new Cell(3, 5), new Cell(3, 6));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [Given(@"I have an empty cell with (.*) adjacent cells")]
        public void GivenIHaveAnEmptyCellWith3AdjacentCells(int numberOfAdjacentCells)
        {
            World world = new World(9, 9);
            ScenarioContext.Current["world"] = world;
            switch (numberOfAdjacentCells)
            {
                case 3:
                    world.AddCells(new Cell(4, 4), new Cell(4, 6), new Cell(3, 5));
                    break;
            }
        }

        [Then(@"the cell dies")]
        public void ThenTheCellDies()
        {
            var world = (World)ScenarioContext.Current["world"];
            Assert.That(world.Cells[4][5], Is.Null);
        }

        [Then(@"the cell lives")]
        public void ThenTheCellLives()
        {
            var world = (World)ScenarioContext.Current["world"];
            Assert.That(world.Cells[4][5], Is.Not.Null);
            Assert.That(world.Cells[4][5].IsAlive, Is.True);
        }

        [Given(@"I have a blinker")]
        public void GivenIHaveABlinker()
        {
            World world = new World(9, 9);
            ScenarioContext.Current["world"] = world;
            world.AddCells(new Cell(4, 4), new Cell(4, 3), new Cell(4, 5));
        }

        [Then(@"the blinker returns to its original shapre")]
        public void ThenTheBlinkerReturnsToItsOriginalShapre()
        {
            var world = (World)ScenarioContext.Current["world"];
            Assert.That(world.Cells.Sum(t => t.Count(t1 => t1 != null)), Is.EqualTo(3));
            Assert.That(world.Cells[4][4].IsAlive, Is.True);
            Assert.That(world.Cells[4][3].IsAlive, Is.True);
            Assert.That(world.Cells[4][5].IsAlive, Is.True);
        }

        [Given(@"I have a toad")]
        public void GivenIHaveAToad()
        {
            World world = new World(9, 9);
            ScenarioContext.Current["world"] = world;
            world.AddCells(new Cell(4, 4), new Cell(5, 4), new Cell(6, 4));
            world.AddCells(new Cell(3, 5), new Cell(4, 5), new Cell(5, 5));
        }

        [Then(@"the toad returns to its original shapre")]
        public void ThenTheToadReturnsToItsOriginalShapre()
        {
            var world = (World)ScenarioContext.Current["world"];
            Assert.That(world.Cells.Sum(t => t.Count(t1 => t1 != null)), Is.EqualTo(6));
            Assert.That(world.Cells[4][4].IsAlive, Is.True);
            Assert.That(world.Cells[5][4].IsAlive, Is.True);
            Assert.That(world.Cells[6][4].IsAlive, Is.True);
            Assert.That(world.Cells[3][5].IsAlive, Is.True);
            Assert.That(world.Cells[4][5].IsAlive, Is.True);
            Assert.That(world.Cells[5][5].IsAlive, Is.True);
        }
    }
}