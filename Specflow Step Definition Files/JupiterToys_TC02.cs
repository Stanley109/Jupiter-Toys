using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_TC02
	{
        
        [When(@"I populate all the mandatory fields with (.*), (.*), and (.*)")]
        public void WhenIpopulateallthemandatoryfieldswithForenameEmailandMessage(string forename, string email, string message)
        {
            var contactPage = new JupiterToys_ContactPage();
            Base.Delay(2);
			Base.SendKeys(contactPage.Textfield_Forename, forename);
			Base.SendKeys(contactPage.Textfield_Email, email);
			Base.SendKeys(contactPage.Textfield_Message, message);
			Base.Delay(2);
        }
        
        [Then(@"a submit feedback alert message should display")]
        public void Thenasubmitfeedbackalertmessageshoulddisplay()
        {
            var contactPage = new JupiterToys_ContactPage();
            Assert.IsTrue(Base.ElementIsDisplayed(contactPage.Alert_SendingFeedback_Message),"Submit Feedback alert message is not displayed.");
        }
        
        [Then(@"a confirmation message should display with the Forename '(.*)' after the feedback alert message disappears")]
        public void ThenaconfirmationmessageshoulddisplaywiththeForenameForenameafterthefeedbackalertmessagedisappears(string forename)
        {
            var contactPage = new JupiterToys_ContactPage();
            Assert.IsTrue(Base.ExplicitlyWaitForElementToDisappear(contactPage.Alert_SendingFeedback_Message),"Feedback alert message did not disappear");
            Base.Delay(2);
            Assert.AreEqual($"Thanks {forename}, we appreciate your feedback.", Base.GetText(contactPage.TextSuccess_Message)); 
        }

	}
}