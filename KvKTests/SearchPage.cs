using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace KvKTests
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"https://www.kvk.nl/zoeken/";

        [FindsBy(How = How.CssSelector, Using = "#js-search-results .more-search-info p")]
        private IWebElement _tradeName;

        [FindsBy(How = How.Id, Using = "q")]
        private IWebElement _search;

        [FindsBy(How = How.CssSelector, Using = ".feedback strong")]
        private IWebElement _countResults;

        [FindsBy(How = How.Name, Using = "site")]
        private IWebElement _filterDropdown;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static SearchPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new SearchPage(driver);
        }

        public string Search
        {
            set
            {
                _search.SendKeys(value);
            }
        }

        public string TradeName => _tradeName.Text;

        public void SelectFilter(string filterName)
        {            
            new SelectElement(_filterDropdown).SelectByText(filterName);
        }

        public string CountResults => _countResults.Text;

    }
}
