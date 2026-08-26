using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages.Impl;

public class HomePage : WebPage
{
    private static readonly By _searchBoxCss = By.CssSelector("#twotabsearchtextbox[name='field-keywords']");

    public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
    {

    }

    public void NavigateToHomePage()
    {
        NavigateToUrl("https://www.amazon.com");
    }

    public void SearchForItem(string item)
    {
        var searchBox = WaitForElementVisible(_searchBoxCss);
        searchBox.SendKeys(item);
        searchBox.SendKeys(Keys.Enter);
    }


}
