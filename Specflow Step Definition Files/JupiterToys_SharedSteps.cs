using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver
{
	[Binding]
	public class JupiterToys_SharedSteps
	{
        [Given(@"I am in the Jupiter Toys home page")]
		public void GivenIamintheJupiterToyshomepage()
		{
			Assert.AreEqual(JupiterToys_Homepage.JupiterToys_Homepage_URL,Base.GetCurrentURL());
		}
    }
}