using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages;

public class WebPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private const int ImplicitWaitTimeoutInSeconds = 10;


    public WebPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    protected IWebElement FindElement(By selector) => _driver.FindElement(selector);

    protected IList<IWebElement> FindElements(By selector) => _driver.FindElements(selector);

    protected IWebElement WaitForElementVisible(By selector, TimeSpan? timeout = null)
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        var wait = timeout.HasValue ? new WebDriverWait(_driver, timeout.Value) : _wait;
        var element = wait.Until(driver => driver.FindElement(selector));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutInSeconds);
        return element;
    }

    protected IList<IWebElement> WaitForElementsVisible(By selector, TimeSpan? timeout = null)
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        var wait = timeout.HasValue ? new WebDriverWait(_driver, timeout.Value) : _wait;
        var elements = wait.Until(driver => driver.FindElements(selector));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutInSeconds);
        return elements;
    }

    protected void NavigateToUrl(string url)
    {
        _driver.Navigate().GoToUrl(url);
        _driver.Manage().Window.Maximize();
    }
}
