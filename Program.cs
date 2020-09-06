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
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine("Navigation to webpage");
        }

        [Test]
        public void ExecuteTest()
        {
            string GoogleSearch = "q";

            string RosarioCentralWeb = "(.//h3[contains(text(),'Rosario Central')])[1]";

            string TodasNotiHover = "(.//h3[contains(text(),'Rosario Central')])[1]";

            string Noticias = "(.//a[contains(@class,'mitem dd')])[1]";

            SeleniumMethods.EnterText(driver, GoogleSearch, "rosario central", "Name");

            driver.FindElement(By.Name(GoogleSearch)).Submit();

            driver.FindElement(By.XPath(RosarioCentralWeb)).Click();

            driver.Manage().Window.Maximize();

            Actions builder = new Actions(driver);

            builder.MoveToElement(driver.FindElement(By.XPath(Noticias))).Perform();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            

            Console.WriteLine("Test Executed");
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
