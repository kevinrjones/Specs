using GameOfLife;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GameOfLifeSpecs
{
    [Binding]
    public class GameOfLifeWorldSteps
    {

        [Given(@"I have an empty world")]
        public void GivenIHaveAnEmptyWorld()
        {
        }

        [Then(@"the world stays empty")]
        public void ThenTheWorldStaysEmpty()
        {
            var world = (World) ScenarioContext.Current["world"];
            Assert.That(world.CellsCount, Is.EqualTo(0));
        }

        [Given(@"I have a world with (.*) adjacent cells")]
        public void GivenIHaveAWorldWithAdjacentCells(int numberOfCells)
        {
            World world =new World(9, 9);
            ScenarioContext.Current["world"] = world;
            int y = 4;
            for (int i = 0; i < numberOfCells; i++)
            {
                world.AddCells(new Cell(4, y + i));
            }
        }

        [Then(@"the world contains (.*) cells")]
        public void ThenTheWorldContainsOneCell(int numberOfCells)
        {
            var world = (World)ScenarioContext.Current["world"];
            Assert.That(world.CellsCount, Is.EqualTo(numberOfCells));
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current["world"] = new World();
        }
    }
}
