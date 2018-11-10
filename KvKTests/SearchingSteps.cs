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

        [Given(@"I am on the KvK homepage")]
        public void GivenIAmOnTheKvKHomepage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://www.kvk.nl/");

            Assert.Equal("KVK", _driver.Title);

            
        }

        [When(@"I search for company ""(.*)""")]
        public void WhenISearchForCompany(string companyName)
        {

            _driver.FindElement(By.LinkText("Zoeken")).Click();

            IWebElement searchInput = _driver.FindElement(By.Id("q"));
            searchInput.SendKeys(companyName);


        }

        [Then(@"I should see the trade name ""(.*)"" displayed")]
        public void ThenIShouldSeeTheTradeNameDisplayed(string name)
        {
            IWebElement tradeNameP = _driver.FindElement(By.CssSelector("#js-search-results .more-search-info p"));
            string tradeName = tradeNameP.Text;

            Assert.Equal(name, tradeName);
        }


    }
}

