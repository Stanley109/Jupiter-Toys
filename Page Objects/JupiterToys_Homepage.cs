using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_Homepage
    {
        public const string JupiterToys_Homepage_URL = "https://jupiter.cloud.planittesting.com/#/";

    //Webelements
        //banner elements
        public By Banner_Contact => By.XPath("//*[@id='nav-contact']/a");
    }
}