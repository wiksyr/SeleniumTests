using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Pages.Impl;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTests;

public class AmazonTests
{
    private static IWebDriver? _driver;
    private static WebDriverWait _wait;

    private const int ImplicitWaitTimeoutInSeconds = 10;
    private const int ExplicitWaitTimeoutInSeconds = 5;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver(); 
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutInSeconds);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(ExplicitWaitTimeoutInSeconds));
    }

    [Test]
    public void CheckSearchItems()
    {
        var searchItem = "laptop";

        var homePage = new HomePage(_driver!, _wait);
        homePage.NavigateToHomePage(); 
        homePage.SearchBox.SearchForItem(searchItem);
        var searchResultsPage = new SearchResultsPage(_driver!, _wait);
        var searchResults = searchResultsPage.ResultItems;

        Assert.That(searchResults.Any(r => r.Text.Contains(searchItem)), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
