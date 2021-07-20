// Generated by Selenium IDE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Xunit;
public class SuiteTests : IDisposable {
  public IWebDriver driver {get; private set;}
  public IDictionary<String, Object> vars {get; private set;}
  public IJavaScriptExecutor js {get; private set;}
  public SuiteTests()
  {
    driver = new FirefoxDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<String, Object>();
  }
  public void Dispose()
  {
    driver.Quit();
  }
  [Fact]
  public void InserirPatrimonioInvalido() {
    driver.Navigate().GoToUrl("https://localhost:5001/");
    driver.Manage().Window.Size = new System.Drawing.Size(1227, 700);
    driver.FindElement(By.Id("login")).Click();
    driver.FindElement(By.Id("Input_Email")).Click();
    driver.FindElement(By.Id("Input_Email")).SendKeys("rafaelsilveirarafa@gmail.com");
    driver.FindElement(By.Id("password")).SendKeys("Deus@pai00");
    driver.FindElement(By.Id("password")).SendKeys(Keys.Enter);
    driver.FindElement(By.Id("password")).SendKeys("Deus@pai00,");
    driver.FindElement(By.CssSelector(".nav:nth-child(8) p")).Click();
    driver.FindElement(By.LinkText("Create New")).Click();
    driver.FindElement(By.CssSelector(".btn-primary")).Click();
    {
      var element = driver.FindElement(By.CssSelector(".btn-primary"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
  }
}
