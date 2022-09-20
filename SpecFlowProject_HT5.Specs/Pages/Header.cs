using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Specs.Pages;

public class Header
{
	private IWebDriver Driver { get; set; }
	private WebDriverWait _wait;
	private IWebElement SearchBar => Driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
	private IWebElement Cart => Driver.FindElement(By.CssSelector("#nav-cart"));
	private IWebElement Account => Driver.FindElement(By.XPath("//span [contains(@id, 'accountList')]"));

	public Header(IWebDriver driver)
	{
		Driver = driver;
		_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
	}

	public bool UserIsLoggedIn()
	{
		var innerText = Account.GetAttribute("innerHTML");
		var name = innerText.Split(", ")[1];
		return name != "sign in";
	}

	public void Search(string textToInput)
	{
		_wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#twotabsearchtextbox")));
		SearchBar.SendKeys(textToInput);
		SearchBar.Submit();
	}

	public void GoToCart()
	{
		Cart.Click();
	}

	public void GoToLogin()
	{
		Account.Click();
	}

	public void TrySwitchTo(string country)
	{
		Driver.FindElement(By.CssSelector("#nav-global-location-popover-link")).Click();
		var dropdown = _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#GLUXCountryList")));

		var dropdownSelector = new SelectElement(dropdown);
		dropdownSelector.SelectByText(country, true);
		
		var doneBtn = _wait.Until(ExpectedConditions.ElementIsVisible(
				By.XPath("//button[@name='glowDoneButton']")));			

		doneBtn.Click();
		Driver.Navigate().Refresh();
	}
	
	public string GetCurrentDeliveryCountry()
	{
		return Driver.FindElement(By.CssSelector("#glow-ingress-line2")).GetAttribute("innerHTML");
	}
}
