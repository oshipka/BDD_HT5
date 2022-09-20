using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Specs.Hooks
{
	[Binding]
	public class Hooks
	{
		public Hooks(IWebDriver driver)
		{
			Driver = driver;
		}

		private static IWebDriver Driver { get; set; }

		[AfterTestRun]
		public static void AfterTestRun()
		{
			Driver.Quit();
			Driver.Dispose();
		}
		
	}
}
