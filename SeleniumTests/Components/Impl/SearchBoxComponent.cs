using OpenQA.Selenium;

namespace SeleniumTests.Components.Impl;

public class SearchBoxComponent(IWebElement rootElement) : WebComponent(rootElement)
{
    public void SearchForItem(string item)
    {
        SendKeys(item);
        SendKeys(Keys.Enter);
    }
}
