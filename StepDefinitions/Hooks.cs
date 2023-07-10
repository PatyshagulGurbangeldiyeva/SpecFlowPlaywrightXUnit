using SpecFlowPlaywrightXUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPlaywrightXUnit.StepDefinitions
{
    [Binding]
    public class Hooks: CommonMethods
    {
        public IPage Driver { get; set; } = null!;
        public IBrowserContext context;
        public static int numberOfFailedTests;
        private ScenarioContext _scenarioContext;
        public IPlaywright playwright;
        
        
        public Hooks( ScenarioContext scenarioContext )
        {
            this._scenarioContext = scenarioContext;
        }

        [BeforeScenario] 
        public async Task BeforeScenario()
        {
            SetUpClass.TestSetUp();
            playwright=await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Timeout = 10000,
                SlowMo=50,
            });
           
            context = await browser.NewContextAsync();
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true,
            });

            Driver = await context.NewPageAsync();

            await Driver.GotoAsync(SetUpClass.URL);
            await Driver.WaitForLoadStateAsync();
        }









        [AfterScenario]
        public async Task AfterScenario()
        {
            string uniqueString = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            uniqueString = uniqueString.Replace("/", "");
            uniqueString = uniqueString.Replace(" ", "");
            uniqueString = uniqueString.Replace(":", "");


         //   if (_scenarioContext.ScenarioExecutionStatus!=ScenarioExecutionStatus.OK) { } >> another way to check scenario failed or not


            if (_scenarioContext.TestError != null && _scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                numberOfFailedTests++;
                await context.Tracing.StopAsync(new()
                {
                    Path = $"{_scenarioContext.ScenarioInfo.Title}_{numberOfFailedTests}_trace.zip"
                });

                await Driver.ScreenshotAsync(new()
                {
                    Path = CommonMethods.GetCurrentProjectDirectory() + "Screenshot\\Failed\\" + uniqueString + $"{_scenarioContext.ScenarioInfo.Title}.png",
                    FullPage = true
                });
            }
            else
            {
                await Driver.ScreenshotAsync(new()
                {
                    Path = CommonMethods.GetCurrentProjectDirectory() + "Screenshot\\Passed\\" + uniqueString + $"{_scenarioContext.ScenarioInfo.Title}.png",
                    FullPage = true
                });
            }
            await Driver.CloseAsync();
            await context.CloseAsync();
            playwright.Dispose();
        }
    }
}
