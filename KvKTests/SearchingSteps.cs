using System;
using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KvKTests
{
    [Binding]
    public class SearchingSteps
    {

        private IWebDriver _driver;
        private SearchPage _searchPage;

        [Given(@"I am on the KvK search page")]
        public void GivenIAmOnTheKvKHomepage()
        {

            _driver = new ChromeDriver();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.Manage().Window.Maximize();

            _searchPage = SearchPage.NavigateTo(_driver);

            Assert.Equal("Zoeken", _driver.Title);  

        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchForCompany(string companyName)
        {

            _searchPage.Search = companyName;
           
        }

        [Then(@"I should see the trade name ""(.*)"" displayed")]
        public void ThenIShouldSeeTheTradeNameDisplayed(string name)
        {

            Assert.Equal(name, _searchPage.TradeName);

        }

        [When(@"I apply filter ""(.*)""")]
        public void WhenIApplyFilter(string filterName)
        {

            _searchPage.SelectFilter(filterName);

        }

        [Then(@"I should see ""(.*)"" results")]
        public void ThenIShouldSeeResults(string count)
        {

            Assert.Equal(count, _searchPage.CountResults);

        }


        [AfterScenario]
        public void DisposeWebdriver()
        {

            _driver.Dispose();

        }

    }
}

