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
            var contactpage = new JupiterToys_Contactpage();

            Base.Delay(2);
			Base.SendKeys(contactpage.Textfield_Forename, forename);
			Base.SendKeys(contactpage.Textfield_Email, email);
			Base.SendKeys(contactpage.Textfield_Message, message);
			Base.Delay(2);
        }

        
        [Then(@"a submit feedback alert message should display")]
        public void Thenasubmitfeedbackalertmessageshoulddisplay()
        {
            var contactpage = new JupiterToys_Contactpage();
            Assert.IsTrue(Base.ElementIsDisplayed(contactpage.Alert_SendingFeedback_Message),"Submit Feedback alert message is not displayed.");
        }
        
        [Then(@"a confirmation message should display with the Forename '(.*)' after the feedback alert message disappears")]
        public void ThenaconfirmationmessageshoulddisplaywiththeForenameForenameafterthefeedbackalertmessagedisappears(string forename)
        {
            var contactpage = new JupiterToys_Contactpage();
            Assert.IsTrue(Base.ExplicitlyWaitForElementToDisappear(contactpage.Alert_SendingFeedback_Message),"Feedback alert message did not disappear");
            Base.Delay(2);
            Assert.AreEqual($"Thanks {forename}, we appreciate your feedback.", Base.GetText(contactpage.TextSuccess_Message)); 
        }

	}
}