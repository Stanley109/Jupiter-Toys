using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_Menu: IJupiterToys
    {
        public string JupiterToys_Default_Page_URL { get; set; }
        public JupiterToys_Menu(string option)
        {
            JupiterToys_Default_Page_URL = "https://jupiter.cloud.planittesting.com/#/home";
            Menu_Option = By.XPath($"//*[@id='nav-{option}']/a");
        }

        //dynamic menu element (home, shop, contact or cart)
        public By Menu_Option;
    }
}