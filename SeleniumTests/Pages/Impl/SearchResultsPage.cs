using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Components.Impl;

namespace SeleniumTests.Pages.Impl;

public class SearchResultsPage : WebPage
{
    private static readonly By _resultItemsCss = By.CssSelector("div[role='listitem']");

    public List<SearchResultItemComponent> ResultItems => WaitForElementsVisible(_resultItemsCss).Select(element => new SearchResultItemComponent(element)).ToList();

    public SearchResultsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
    {
    }

}
