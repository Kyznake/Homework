using Homework.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Homework
{
    public class UI
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.emag.ro/");
        }

        [Test, Order(0)]
        public void AddTwoProductsToCart()
        {
            //Arrange

            //Act
            driver
                 .Add2ItemsToCart();

            //Assert
            var numberOfCartElements = driver
                .FindElement(By.XPath("//span[contains(@title, '2')]"))
                .Text;
            Assert.That(numberOfCartElements, Is.EqualTo("2"));
        }

        [Test, Order(1)]
        public void RemoveOneItemFromCart()
        {
            //Arrange
            driver
                .Add2ItemsToCart();
            Thread.Sleep(1000);
            var numberOfElementsFromCart = 1;

            //Act
            var numberOfCartElements = driver
                .FindElement(By.XPath("//span[contains(@class, 'select2-selection select2-selection--single')]"));
            Assert.That(numberOfCartElements.Text, Is.EqualTo("2"));
            driver
                .ChangeNumberOfElementsFromCart(numberOfElementsFromCart);

            //Assert
            numberOfCartElements = driver
                .FindElement(By.XPath("//span[contains(@class, 'select2-selection select2-selection--single')]"));
            Assert.That(numberOfCartElements.Text, Is.EqualTo("1"));
        }

        [Test, Order(2)]
        public void RemoveTwoItemsFromCart()
        {
            //Arrange
            driver
                .Add2ItemsToCart();
            Thread.Sleep(1000);
            var numberOfElementsFromCart = 0;

            //Act
            var numberOfCartElements = driver
                .FindElement(By.XPath("//span[contains(@class, 'select2-selection select2-selection--single')]"));
            Assert.That(numberOfCartElements.Text, Is.EqualTo("2"));
            driver
                .ChangeNumberOfElementsFromCart(numberOfElementsFromCart);

            //Assert
            Assert.That(driver.FindElement(By.XPath("//*[contains(text(), 'Cosul tau este gol')]")).Text, Is.EqualTo("Cosul tau este gol"));
        }

        [Test, Order(3)]
        public void TryRemovingWhenNoItemInCart()
        {
            //Arrange
            driver
                .Add2ItemsToCart();
            Thread.Sleep(1000);
            var numberOfElementsFromCart = 0;
            var elementPresent = true;

            //Act
            var numberOfCartElements = driver
                .FindElement(By.XPath("//span[contains(@class, 'select2-selection select2-selection--single')]"));
            Assert.That(numberOfCartElements.Text, Is.EqualTo("2"));
            driver
                .ChangeNumberOfElementsFromCart(numberOfElementsFromCart);

            //Assert
            try
            {
                driver
                    .ChangeNumberOfElementsFromCart(numberOfElementsFromCart);
            }
            catch (Exception)
            {
                elementPresent = false;
            }
            if (elementPresent)
            {
                throw new Exception("Remove button doesn't exist after removing all the products from cart.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}