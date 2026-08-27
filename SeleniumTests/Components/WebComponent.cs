using OpenQA.Selenium;

namespace SeleniumTests.Components;

public class WebComponent
{
    private readonly IWebElement _rootElement; 

    public WebComponent(IWebElement rootElement)
    {
        _rootElement = rootElement;
    }

    public IWebElement FindElement(By selector) => _rootElement.FindElement(selector);

    public void Click() => _rootElement.Click();

    public string Text => _rootElement.Text;

    public void SendKeys(string text) => _rootElement.SendKeys(text);

}
