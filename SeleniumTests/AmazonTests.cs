using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTests;

public class AmazonTests
{
    private static IWebDriver? _driver;
    private static WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver(); 
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    [Test]
    public void CheckSearchItems()
    {
        var searchItem = "macbook"; 
        _driver?.Navigate().GoToUrl("https://www.amazon.com");

        _driver?.Manage().Window.Maximize();
        _driver?.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        var searchBox = _wait.Until(driver => driver.FindElement(By.CssSelector("#twotabsearchtextbox[name='field-keywords']")));
        _driver?.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        searchBox.SendKeys("laptop");
        searchBox.SendKeys(Keys.Enter);

        _driver?.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        var results = _wait.Until(driver => driver.FindElements(By.CssSelector("div[role='listitem']")));
        _driver?.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        var resultItems = results.Select(r => r.Text).ToList();
        Assert.That(resultItems.Contains(searchItem), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Dispose();
    }
}
