using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_TC03
	{
        public static List<Purchases> products = new List<Purchases>();

        [When(@"I add the following products")]
        public void WhenIaddthefollowingproducts(Table table)
        {
            var purchases = table.CreateSet<Purchases>();
            var shopPage = new JupiterToys_ShopPage();
            foreach (var product in purchases)
            {
                shopPage.AddItemsToCart(product.Product!, product.Quantity);
                products.Add(product);
            }
        }
        
        [Then(@"I should be able to verify the price of each product")]
        public void ThenIshouldbeabletoverifythepriceofeachproduct()
        {
            var cartPage = new JupiterToys_CartPage();
            bool isCorrect = false;
            foreach(var product in products)
            {
                isCorrect = cartPage.VerifyPriceOfEachProduct(product.Product!, product.Price);
            }
            Assert.IsTrue(isCorrect);
        }

        [Then(@"I should be able to verify the subtotal price of each product")]
        public void ThenIshouldbeabletoverifythesubtotalpriceofeachproduct()
        {
            var cartPage = new JupiterToys_CartPage();
            bool isCorrect = false;
            foreach(var product in products)
            {
                isCorrect = cartPage.VerifySubtotalOfEachProduct(product.Product!, product.Price, product.Quantity);
            }
            Assert.IsTrue(isCorrect);
        }

        [Then(@"I should be able to verify the total price")]
        public void ThenIshouldbeabletoverifythetotalprice()
        {
            var cartPage = new JupiterToys_CartPage();
            bool isCorrect = cartPage.VerifyTotalPrice();
            Base.Delay(3);
            Assert.IsTrue(isCorrect);
        }
    }

    public class Purchases
    {
        public string? Product;
        public double Price;
        public int Quantity;
    }
}