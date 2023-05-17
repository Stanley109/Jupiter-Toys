using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_TC01
	{
		[Then(@"I should be able to see the error messages in each missing mandatory fields")]
		public void ThenIshouldbeabletoseetheerrormessagesineachmissingmandatoryfields()
		{
			Base.Delay(3);
			var contactpage = new JupiterToys_Contactpage();

			Assert.Multiple(() =>
    		{
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Forename),"Forename error message is not displayed.");
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Email),"Email error message is not displayed.");
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Message),"Message error message is not displayed.");
   			});
		}

		[When(@"I populate the mandatory fields")]
		public void WhenIpopulatethemandatoryfields(Table table)
		{
			var textfields = table.CreateInstance<Textfields>();
			var contactpage = new JupiterToys_Contactpage();

			Base.Delay(2);
			Base.SendKeys(contactpage.Textfield_Forename, textfields.Forename);
			Base.SendKeys(contactpage.Textfield_Email, textfields.Email);
			Base.SendKeys(contactpage.Textfield_Message, textfields.Message);
			Base.Delay(2);
		}
		
		[Then(@"the error message in the contact page form should disappear")]
		public void Thentheerrormessageinthecontactpageformshoulddisappear()
		{	
			var contactpage = new JupiterToys_Contactpage();
			Base.Delay(2);
			Assert.Multiple(() =>
    		{
				Assert.IsTrue(Base.ExplicitlyWaitForElementToDisappear(contactpage.TextError_Forename),"Forename error message is still displayed.");
				Assert.IsTrue(Base.ExplicitlyWaitForElementToDisappear(contactpage.TextError_Email),"Email error message is still displayed");
				Assert.IsTrue(Base.ExplicitlyWaitForElementToDisappear(contactpage.TextError_Message),"Message error message is still displayed.");
   			});
		}
	}
	public class Textfields
    {
        public string? Forename {get;set;}
		public string? Email {get;set;}
		public string? Message {get;set;}
    }
}