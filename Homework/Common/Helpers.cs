using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Homework.Common
{
    public static class Helpers
    {
        public static IWebDriver GoToUrl(this IWebDriver webDriver, string url)
        {
            webDriver
                .Navigate()
                .GoToUrl(url);

            return webDriver;
        }

        public static IWebElement ExecuteJS(this IWebElement webElement, IWebDriver webDriver, string script)
        {
            // Parse to ScriptExecutor.
            var scriptExecutor = (IJavaScriptExecutor)webDriver;

            // Execute script.
            scriptExecutor.ExecuteScript(script, webElement);

            return webElement;
        }

        public static IWebElement ScrollTo(this IWebElement webElement, IWebDriver webDriver)
        {
            return webElement.ExecuteJS(webDriver, "arguments[0].scrollIntoView(true);");
        }

        public static IWebElement SendKeys(this IWebElement webElement, IWebDriver webDriver, bool clear, params string[] keys)
        {
            // Select all instead of clear.
            if (clear && new[] { "input", "textarea" }.Contains(webElement.TagName, StringComparer.OrdinalIgnoreCase))
            {
                Actions action = new Actions(webDriver);
                action.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
                webElement.SendKeys(Keys.Backspace);
            }

            if (keys?.Any() == true)
            {
                var a = new Actions(webDriver).MoveToElement(webElement.ScrollTo(webDriver));

                // Append keys.
                foreach (var k in keys)
                {
                    a = a.SendKeys(webElement, k);
                }

                // Perform actions.
                a.Perform();
            }

            // Return the web element.
            return webElement;
        }

        public static IWebElement SetText(this IWebElement webElement, IWebDriver webDriver, string value, bool clear = false)
        {
            return SendKeys(webElement, webDriver, clear, value);
        }
    }
}
