using System;
using TechTalk.SpecFlow;

namespace SpecFlowPlaywrightXUnit.StepDefinitions
{
    [Binding]
    public class VerifyLinkFuntionalityStepDefinitions: CommonMethods
    {

        private readonly IPage _page;
        private readonly AmazonDashboardPage _amazonDashboardPage;
        private ISpecFlowOutputHelper _specflowOutPutHelper;
        private ScenarioContext _scenarioContext;



        public VerifyLinkFuntionalityStepDefinitions(Hooks hooks, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
            _page = hooks.Driver;
            _scenarioContext = scenarioContext;
            _amazonDashboardPage = new AmazonDashboardPage(hooks, specFlowOutputHelper);
            _specflowOutPutHelper = specFlowOutputHelper;
        }





        [Given(@"User sees Amazon icon on dahsboard")]
        public async Task GivenUserSeesAmazonIconOnDahsboard()
        {
            bool isVisible=await _amazonDashboardPage.amazonIcon.IsVisibleAsync();
            Assert.True(isVisible);

            string expectedIcon = "Amazon";
            string actualIcon =await _amazonDashboardPage.amazonIcon.GetAttributeAsync("aria-label");
            _specflowOutPutHelper.WriteLine("amazon text: " + actualIcon);
            Assert.Equal(expectedIcon, actualIcon);


          
        }

        [Then(@"Amazon icon has link")]
        public async Task ThenAmazonIconHasLink()
        {
            string expectedEndPoint = "/ref=nav_logo";
          //  string expectedLinkUrl = "www.amazon.com/ref=nav_logo";

            string href = await _amazonDashboardPage.amazonIcon.GetAttributeAsync("href");
            _specflowOutPutHelper.WriteLine("href: " + href);
            Assert.Equal(expectedEndPoint, href);
          

        }


        [Given(@"User clicks on Clinic tab")]
        public async Task GivenUserClicksOnClinicTab()
        {
            await _amazonDashboardPage.clinic.ClickAsync();
        }

        [Then(@"User navigates Clinic page on the same window")]
        public async Task ThenUserNavigatesClinicPageOnTheSameWindow()
        {
            // how to verify page title
            // how to verify page url
            //how to verify count of Pages
        }

    }
}
