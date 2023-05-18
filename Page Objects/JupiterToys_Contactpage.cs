using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_ContactPage: IJupiterToys
    {
        public string JupiterToys_Default_Page_URL { get; set; }
        public JupiterToys_ContactPage()
        {
            JupiterToys_Default_Page_URL = "https://jupiter.cloud.planittesting.com/#/contact";
        }

    //Webelements
        //text fields
        public By Textfield_Forename = By.XPath("//*[@id='forename']");
        public By Textfield_Email = By.XPath("//*[@id='email']");       
        public By Textfield_Message = By.XPath("//*[@id='message']");

        //buttons        
        public By Button_Submit = By.XPath("//*[contains(text(),'Submit')]");

        //error messages
        public By TextError_Forename = By.XPath("//*[@id='forename-err']");
        public By TextError_Email = By.XPath("//*[@id='email-err']");
        public By TextError_Message = By.XPath("//*[@id='message-err']");

        //success texts
        public By TextSuccess_Message = By.XPath("//*[contains(@class,'alert alert-success')]");

        //submit feedback alert message
        public By Alert_SendingFeedback_Message = By.XPath("//*[contains(text(),'Sending Feedback')]");
        
    }
}