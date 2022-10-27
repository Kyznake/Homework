using Homework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Homework
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.emag.ro/");
        }

        [Test]
        public void Test1()
        {
            //Arrange
            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("//button[contains(@class, 'btn btn-primary js-accept gtm_h76e8zjgoo btn-block')]"))
                .Click();
            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("//button[contains(@class, 'js-dismiss-login-notice-btn dismiss-btn btn btn-link pad-sep-none pad-hrz-none')]"))
                .Click();
            var listOfElement = driver
                .FindElements(By.XPath("//button[contains(@class, 'btn btn-sm btn-primary btn-emag btn-block yeahIWantThisProduct')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(listOfElement[0]);
            actions.Perform();
            
            //Act
            listOfElement[0].Click();
            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("//button[contains(@class, 'close gtm_6046yfqs')]"))
                .Click();
            Thread.Sleep(1000);
            listOfElement[0].Click();
            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("//a[contains(@class, 'btn btn-primary btn-sm btn-block')]"))
                .Click();
            Thread.Sleep(1000);

            //Assert
            var numberOfCartElement = driver
                .FindElement(By.XPath("//span[contains(@title, '2')]"))
                .Text;
            Assert.That(numberOfCartElement, Is.EqualTo("2"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}