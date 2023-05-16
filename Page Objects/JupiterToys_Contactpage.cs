using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_Contactpage
    {
        public const string JupiterToys_Contactpage_URL = "https://jupiter.cloud.planittesting.com/#/contact";

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
        
    }
}