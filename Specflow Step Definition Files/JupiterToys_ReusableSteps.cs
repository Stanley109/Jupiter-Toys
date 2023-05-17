using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_SharedSteps
	{
        [Given(@"I am in the Jupiter Toys home page")]
		public void GivenIamintheJupiterToyshomepage()
		{
			Base.GoToURL(JupiterToys_Homepage.JupiterToys_Homepage_URL);
			Base.Delay(3);
			Assert.AreEqual(JupiterToys_Homepage.JupiterToys_Homepage_URL,Base.GetCurrentURL());
		}
		
		[When(@"I visit the contact page")]
        public void WhenIvisitthecontactpage()
        {
            var homepage = new JupiterToys_Homepage();
			Base.ClickElement(homepage.Banner_Contact);
        }
        
        [When(@"I click the submit button")]
        public void WhenIclickthesubmitbutton()
        {
            var contactpage = new JupiterToys_Contactpage();
            Base.ClickElement(contactpage.Button_Submit);
        }
    }
}
