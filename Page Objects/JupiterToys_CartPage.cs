using System;
using OpenQA.Selenium;

namespace SeleniumWebdriver
{
    public class JupiterToys_CartPage: IJupiterToys
    {
        public string JupiterToys_Default_Page_URL { get; set; }
        public static double ExpectedTotalPrice;
        public JupiterToys_CartPage()
        {
            JupiterToys_Default_Page_URL = "https://jupiter.cloud.planittesting.com/#/cart";
        }

        public By? Text_Dynamic_Price;
        public By? Text_Dynamic_Quantity;
        public By? Text_Dynamic_Subtotal; 
        public By  Text_Total = By.XPath("//*[contains(@class,'total ng-binding')]");
        
        public Boolean VerifySubtotalOfEachProduct(string product, double price, int quantity)
        {
            Text_Dynamic_Subtotal = By.XPath($"//td[contains(text(),'{product}')]//following-sibling::td[3]");
            ExpectedTotalPrice = ExpectedTotalPrice + (price * quantity);
            var expectedSubtotal = (price * quantity).ToString();
            var actualSubtotal = Base.GetText(Text_Dynamic_Subtotal)!.Replace("$","");
            Console.WriteLine(expectedSubtotal + " is equal to " + actualSubtotal);
            return string.Equals(expectedSubtotal, actualSubtotal);
        }

        public Boolean VerifyPriceOfEachProduct(string product, double price)
        {
            Text_Dynamic_Price = By.XPath($"//td[contains(text(),'{product}')]//following-sibling::td[1]");
            var expectedProductPrice = price.ToString();
            var actualProductPrice = Base.GetText(Text_Dynamic_Price)!.Replace("$","");
            Console.WriteLine(expectedProductPrice + " is equal to " + actualProductPrice);
            return string.Equals(expectedProductPrice, actualProductPrice);
        }

        public Boolean VerifyTotalPrice()
        {
            var actualTotalPrice = double.Parse(Base.GetText(Text_Total)!.Replace("Total:","").Trim());
            return double.Equals(ExpectedTotalPrice, actualTotalPrice);
        }
    }
}