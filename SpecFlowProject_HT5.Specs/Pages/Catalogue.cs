using OpenQA.Selenium;

namespace SpecFlowProject.Specs.Pages;

public class Catalogue
{
	private IWebDriver Driver { get; set; }
	public Catalogue(IWebDriver driver)
	{
		Driver = driver;
	}
}
