using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_TC01
	{
		public static Textfields? textfields;

		[When(@"I visit the contact page and click the submit button")]
		public void WhenIvisitthecontactpageandclickthesubmitbutton()
		{
			var homepage = new JupiterToys_Homepage();
			var contactpage = new JupiterToys_Contactpage();

			Base.ClickElement(homepage.Banner_Contact);
			Base.ClickElement(contactpage.Button_Submit);
			
		}

		[Then(@"I should be able to see the error messages in each missing mandatory fields")]
		public void ThenIshouldbeabletoseetheerrormessagesineachmissingmandatoryfields()
		{
			var contactpage = new JupiterToys_Contactpage();

			Assert.Multiple(() =>
    		{
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Forename),"Forename error message is not displayed.");
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Email),"Email error message is not displayed.");
				Assert.IsTrue(Base.ElementIsDisplayed(contactpage.TextError_Message),"Message error message is not displayed.");
   			});
		}

		[When(@"I populate the mandatory fields and click the submit button")]
		public void WhenIpopulatethemandatoryfieldsandclickthesubmitbutton(Table table)
		{
			textfields = table.CreateInstance<Textfields>();
			var contactpage = new JupiterToys_Contactpage();

			Base.SendKeys(contactpage.Textfield_Forename, textfields.Forename);
			Base.SendKeys(contactpage.Textfield_Email, textfields.Email);
			Base.SendKeys(contactpage.Textfield_Message, textfields.Message);
			Base.ClickElement(contactpage.Button_Submit);
		}

		[Then(@"the error message in the contact page form should disappear")]
		public void Thentheerrormessageinthecontactpageformshoulddisappear()
		{	
			var contactpage = new JupiterToys_Contactpage();
			Assert.Multiple(() =>
    		{
				Assert.IsFalse(Base.ElementIsDisplayed(contactpage.TextError_Forename),"Forename error message is still displayed.");
				Assert.IsFalse(Base.ElementIsDisplayed(contactpage.TextError_Email),"Email error message is still displayed");
				Assert.IsFalse(Base.ElementIsDisplayed(contactpage.TextError_Message),"Message error message is still displayed.");
   			});
		}

		
		[Then(@"a confirmation message should display")]
		public void Thenaconfirmationmessageshoulddisplay()
		{
			var contactpage = new JupiterToys_Contactpage();
			Assert.AreEqual($"Thanks {textfields!.Forename}, we appreciate your feedback.", Base.GetText(contactpage.TextSuccess_Message));
		}

	}

	public class Textfields
    {
        public string? Forename {get;set;}
		public string? Email {get;set;}
		public string? Message {get;set;}
    }
}