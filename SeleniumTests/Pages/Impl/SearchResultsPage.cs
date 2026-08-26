using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages.Impl;

public class SearchResultsPage : WebPage
{
    private static readonly By _resultItemsCss = By.CssSelector("div[role='listitem']");

    public SearchResultsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
    {
    }

    public IList<string> GetResults()
    {
        var results = WaitForElementsVisible(_resultItemsCss, TimeSpan.FromSeconds(10));
        return results.Select(r => r.Text).ToList();
    }
}
