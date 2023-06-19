using SpecFlowPlaywrightXUnit.StepDefinitions;
using SpecFlowPlaywrightXUnit.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPlaywrightXUnit.Pages
{
    public class AmazonDashboardPage: CommonMethods
    {
        private IPage _page;
        public ISpecFlowOutputHelper _specflowOutPutHelper;

        public AmazonDashboardPage(Hooks hooks, ISpecFlowOutputHelper specflowOutPutHelper)
        {
            _page = hooks.Driver;
            _specflowOutPutHelper = specflowOutPutHelper;
        }

        public ILocator clinic => _page.GetByRole(AriaRole.Link, new() { Name = "Clinic" });
       // public ILocator clinic => _page.Locator("css=#nav-xshop > a:nth-child(3)");
        public ILocator bestSeller => _page.GetByRole(AriaRole.Link, new() { Name = "Best Sellers" });
        public ILocator customerService => _page.GetByRole(AriaRole.Link, new() { Name = "Customer Service" });
    }
}
