using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("http://www.google.com");

            //thisisatest

            driver.FindElement(By.XPath(""));

            IWebElement pedrito = driver.FindElement(By.XPath(""));

            pedrito.Click();

            driver.SwitchTo().Frame("");

            driver.SwitchTo().ParentFrame();

            var aliadito = "pepito";

            driver.FindElement(By.XPath("")).SendKeys("asgadg");

            Console.ReadLine();

            Console.WriteLine(aliado.Length);

            var a = Console.ReadLine();
        }
    }
}
