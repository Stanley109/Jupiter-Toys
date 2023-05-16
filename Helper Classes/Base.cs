
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumWebdriver
{	
	class Base
  	{
		public static string BasePath = Directory.GetCurrentDirectory().Substring(0,Directory.GetCurrentDirectory().Length-new string("\\bin\\Debug\\net7.0\\").Length+1);
		public static IWebDriver WebDriver=null!;

		public static void SetupBrowser()
		{
		    new DriverManager(Base.BasePath).SetUpDriver(new ChromeConfig(),VersionResolveStrategy.MatchingBrowser);
			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");
       		options.AddArgument("--disable-notifications");
            WebDriver = new ChromeDriver(options);
			WebDriver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(3);
		}

		public static void ImplicitlyWait(int sec)
		{
			WebDriver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(sec);
		}

		public static void Delay(int sec)
		{
			Thread.Sleep(sec);
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
			catch(Exception e)
			{
				Assert.Fail(e.Message);
			}
		}

		public static void ClickElement(By element)
		{
			try
			{
				WebDriver.FindElement(element).Click();
			}
			catch(Exception e)
			{
				Assert.Fail(e.Message);
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
			catch(Exception e)
			{
				Assert.Fail(e.Message);
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
				Assert.Fail();
			}
		}

	}
	
}