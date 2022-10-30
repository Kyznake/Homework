using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Homework.Common
{
    public static class Helpers
    {
        public static IWebDriver ChangeNumberOfElementsFromCart(this IWebDriver webDriver, int numberOfItems)
        {
            
            if(numberOfItems - 1 >= 0)
            {
                var numberOfCartElements = webDriver
                .FindElement(By.XPath("//span[contains(@class, 'select2-selection select2-selection--single')]"));
                numberOfCartElements.Click();
                Thread.Sleep(1000);
                var listOfValues = webDriver
                    .FindElements(By.XPath("//ul[contains(@class, 'select2-results__options')]/li"));
                listOfValues[numberOfItems - 1].Click();
            }
            else
            {
                webDriver
                    .FindElement(By.XPath("//a[contains(@class, 'emg-right remove-product btn-remove-product gtm_rp080219')]"))
                    .Click();
                Thread.Sleep(2000);
            }
            return webDriver;
        }
        public static IWebDriver Add2ItemsToCart(this IWebDriver webDriver)
        {
            Thread.Sleep(1000);
            webDriver
                .FindElement(By.XPath("//button[contains(@class, 'btn btn-primary js-accept gtm_h76e8zjgoo btn-block')]"))
                .Click();
            Thread.Sleep(1000);
            webDriver
                .FindElement(By.XPath("//button[contains(@class, 'js-dismiss-login-notice-btn dismiss-btn btn btn-link pad-sep-none pad-hrz-none')]"))
                .Click();
            var listOfElements = webDriver
               .FindElements(By.XPath("//button[contains(@class, 'btn btn-sm btn-primary btn-emag btn-block yeahIWantThisProduct')]"));
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(listOfElements[0]);
            actions.Perform();
            listOfElements[0].Click();
            Thread.Sleep(1000);
            webDriver
                .FindElement(By.XPath("//button[contains(@class, 'close gtm_6046yfqs')]"))
                .Click();
            Thread.Sleep(1000);
            listOfElements[0].Click();
            Thread.Sleep(1000);
            webDriver
                .FindElement(By.XPath("//a[contains(@class, 'btn btn-primary btn-sm btn-block')]"))
                .Click();
            Thread.Sleep(1000);
            return webDriver;
        }
    }
}
