using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Components.Impl;

namespace SeleniumTests.Pages.Impl;

public class HomePage : WebPage
{
    private static readonly By _searchBoxCss = By.CssSelector("#twotabsearchtextbox[name='field-keywords']");

    public SearchBoxComponent SearchBox => new SearchBoxComponent(WaitForElementVisible(_searchBoxCss));

    public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
    {

    }

    public void NavigateToHomePage()
    {
        NavigateToUrl("https://www.amazon.com");
    }
}
