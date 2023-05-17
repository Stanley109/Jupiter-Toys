
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;



namespace SeleniumWebdriver
{	
	class Base
  	{
		public static string BasePath = Directory.GetCurrentDirectory().Substring(0,Directory.GetCurrentDirectory().Length-new string("\\bin\\Debug\\net7.0\\").Length+1);
		public static IWebDriver WebDriver=null!;

		public const int ImplicitWaitSeconds = 10;
		public const int ExplicitWaitSeconds = 15;

		public static void SetupBrowser()
		{
		    new DriverManager(Base.BasePath).SetUpDriver(new ChromeConfig(),VersionResolveStrategy.MatchingBrowser);
			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");
       		options.AddArgument("--disable-notifications");
            WebDriver = new ChromeDriver(options);
			WebDriver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(ImplicitWaitSeconds);
			WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
		}

		public static void ImplicitlyWait(int sec)
		{
			WebDriver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(sec);
		}

		public static Boolean ExplicitlyWaitForElementToDisappear(By element)
		{
			try
			{	
				ImplicitlyWait(0);
				WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(ExplicitWaitSeconds));
				var isHidden = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(element));
				ImplicitlyWait(ImplicitWaitSeconds);
           		return isHidden; 
			}
			catch
			{
				return false;
			}
			
		}

		public static void Delay(int sec)
		{
			Thread.Sleep(TimeSpan.FromSeconds(sec));
		}

		public static void GoToURL(string url)
		{
			WebDriver.Url = url;
		}

		public static string GetCurrentURL()
		{
			return WebDriver.Url;
		}

		public static void HoverToElement(By element)
		{
			try
			{
				Actions action = new Actions(WebDriver);
				action.MoveToElement(WebDriver.FindElement(element));
				action.Perform();
			}
			catch
			{
				Assert.Fail($"Failed to hover to the element {element.ToString()}");
			}
		}

		public static void ClickElement(By element)
		{
			try
			{
				WebDriver.FindElement(element).Click();
			}
			catch
			{
				Assert.Fail($"Failed to click element for {element.ToString()}");
			}	
		}

		/// <summary>
		/// Parses the text of the provided webelement
		/// </summary>
		public static string? GetText(By element)
		{
			try
			{
				return WebDriver.FindElement(element).Text;
			}
			catch
			{
				Assert.Fail($"Failed to get text for element: {element.ToString()}");
				return null;
			}
		}

		public static Boolean ElementIsDisplayed(By element)
		{
			try
			{
				return WebDriver.FindElement(element).Displayed;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Sends a string value to the 'WebElement' with the provided 'text'
		/// </summary>
		public static void SendKeys(By element, string? text)
		{
			try
			{
				WebDriver.FindElement(element).SendKeys(text);
			}
			catch
			{
				Assert.Fail($"Failed to send keys for element {element.ToString()}");
			}
		}

	}
}