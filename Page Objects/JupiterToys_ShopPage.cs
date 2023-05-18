using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_ShopPage: IJupiterToys
    {
        public string JupiterToys_Default_Page_URL { get; set; }
        public JupiterToys_ShopPage()
        {
            JupiterToys_Default_Page_URL = "https://jupiter.cloud.planittesting.com/#/shop";
        }

        public By? Button_Buy; 

        //methods
        public void AddItemsToCart(string item, int Quantity)
        {
            Button_Buy = By.XPath($"//h4[contains(text(),'{item}')]//following-sibling::p//a");
            for(var i=1; i<=Quantity; i++)
            {
                Base.ClickElement(Button_Buy);
                Base.Delay(1);
            }
        }
    }
}