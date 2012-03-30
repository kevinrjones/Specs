using GameOfLife;
using TechTalk.SpecFlow;

namespace GameOfLifeSpecs
{
    [Binding]
    public class CommonSteps
    {
        [When(@"The clock ticks (.*) time\(s\)")]
        public void WhenTheClockTicks(int numberOfTicks)
        {
            var world = (World) ScenarioContext.Current["world"];
            for (int i = 0; i < numberOfTicks; i++)
            {
                world.Tick();
            }
        }
    }
}