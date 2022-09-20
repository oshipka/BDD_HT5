using OpenQA.Selenium;

namespace SpecFlowProject.Specs.Pages;

public class HomePage
{
	private const string PAGE_URL = "https://www.amazon.com/ref=ap_frn_logo";

	private static IWebDriver Driver { get; set; }
	public HomePage(IWebDriver driver)
	{
		Driver = driver;
	}

	public static void GoTo()
	{
		Driver.Navigate().GoToUrl(PAGE_URL);
	}
}
