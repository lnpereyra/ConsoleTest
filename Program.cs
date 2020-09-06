using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace ConsoleApp2
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine("Navigation to webpage");
        }

        [Test]
        public void ExecuteTest()
        {
            //Arrange
            string GoogleSearch = "q";

            string AmazonWeb = "(.//a[contains(@href,'www.amazon.com')])[1]";

            string HoverCuenta = "nav-link-accountList";

            string Cuenta = ".//span[contains(text(),'Tu Cuenta')]";

            string Covid = ".//a[contains(@href,'blog.aboutamazon')]";

            string CovidPop = null;

            SeleniumMethods.EnterText(driver, GoogleSearch, "amazon", "Name");

            driver.FindElement(By.Name(GoogleSearch)).Submit();

            driver.FindElement(By.XPath(AmazonWeb)).Click();            

            System.Threading.Thread.Sleep(1000);

            Actions hover = new Actions(driver);

            hover
                .MoveToElement(driver.FindElement(By.Id(HoverCuenta)))
                .Build()
                .Perform();

            driver.FindElement(By.XPath(Cuenta)).Click();

            Console.WriteLine("Menu Mi Cuenta abierto");

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Test Executed");

            //Act

            try
            {
                CovidPop = driver.FindElement(By.XPath(Covid)).Text;
            }
            catch (Exception)
            {
                throw new Exception("The element Covid is not present in the amazon Account Profile");
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("(//span[contains(text(),'Identif')])[3]")));

            System.Threading.Thread.Sleep(2000);

            //Assert
            Assert.IsTrue(CovidPop == "Respuesta ante el COVID-19");
        }

        [Test]
        public void Test1()
        {
        }

        [Test]
        public void Test2()
        {
        }

        [TearDown]
        public void Clean()
        {
            driver.Close();

        }
    }
}
