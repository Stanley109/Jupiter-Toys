using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_SharedSteps
	{
        [Given(@"I visit the Home page")]
		public void GivenIvisittheHomepage()
		{
            var homepage = new JupiterToys_Menu("home");
            Base.ClickElement(homepage.Menu_Option);
            Base.Delay(2);
			Assert.AreEqual(homepage.JupiterToys_Default_Page_URL,Base.GetCurrentURL());
		}

        [When(@"I visit the (.*) page")]
		public void WhenIvisitthepage(string menu)
		{
            var homepage = new JupiterToys_Menu(menu.ToLower());
            Base.ClickElement(homepage.Menu_Option);
            Base.Delay(2);
            IJupiterToys page;
            switch(menu.ToLower()) 
            {
                case "shop": page = new JupiterToys_ShopPage(); break;        
                case "contact": page = new JupiterToys_ContactPage(); break;       
                case "cart": page = new JupiterToys_CartPage(); break;
                default: page = new JupiterToys_Menu(menu); break;
            }
			Assert.AreEqual(page.JupiterToys_Default_Page_URL,Base.GetCurrentURL());
		}
        
        [When(@"I click the Contact page submit button")]
        public void WhenIclicktheContactpagesubmitbutton()
        {
            var contactpage = new JupiterToys_ContactPage();
            Base.ClickElement(contactpage.Button_Submit);
        }
    }
}
