namespace SpecFlowPlaywrightXUnit.StepDefinitions
{
    [Binding]
    public class AmazonDashboardStepDefinitions : CommonMethods
    {
        private readonly IPage _page;
        private readonly AmazonDashboardPage _amazonDashboardPage;
        private ISpecFlowOutputHelper _specflowOutPutHelper;
        private ScenarioContext _scenarioContext;
        


        public AmazonDashboardStepDefinitions(Hooks hooks, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
            _page = hooks.Driver;
            _scenarioContext = scenarioContext;
            _amazonDashboardPage =new AmazonDashboardPage(hooks, specFlowOutputHelper);
            _specflowOutPutHelper = specFlowOutputHelper;
        }




        [Given(@"user sees tabs")]
        public async Task  GivenUserSeesTabs(Table table)
        {
            //get Options from the feature file
            List<string> featureOptions = new List<string>();
            foreach (var row in table.Rows)
            {
                foreach (string value in row.Values)
                {
                    _specflowOutPutHelper.WriteLine("Values: "+$"{value}\r\n");
                    featureOptions.Add(value);
                }
            }

            var clinics = await _amazonDashboardPage.clinic.TextContentAsync();
            _specflowOutPutHelper.WriteLine(clinics);

            var bestSeller = await _amazonDashboardPage.bestSeller.TextContentAsync();
            _specflowOutPutHelper.WriteLine(bestSeller);

            var customerService = await _amazonDashboardPage.customerService.TextContentAsync();
            _specflowOutPutHelper.WriteLine(customerService);

            List <string> UIElements=new List<string>();
            UIElements.Add(clinics);
            UIElements.Add(bestSeller);
            UIElements.Add(customerService);

            Assert.True(featureOptions.SequenceEqual(UIElements));

        }

    }
}