using System.Collections.ObjectModel;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Specs.Pages;

public class Catalogue
{
	private List<string> ranges = new()
	{
		"Under $25", "$25 to $50", "$50 to $100", "$100 to $200",
		"$200 & Above"
	};

	private IWebDriver Driver { get; set; }
	private WebDriverWait _wait;
	private ReadOnlyCollection<IWebElement> Prices => Driver.FindElements(By.CssSelector("#priceRefinements>ul>li"));
	private ReadOnlyCollection<IWebElement> Items => Driver.FindElements(By.XPath("//div[@data-component-type='s-search-result']"));
	public Catalogue(IWebDriver driver)
	{
		Driver = driver;
		_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
	}

	public void ClickPriceRange(string range)
	{
		var action = new Actions(Driver);
		action.MoveToElement(Prices[ranges.IndexOf(range)], 2, 2).Click();
	}

	public bool ItemsAreDisplayed()
	{
		_wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-component-type='s-search-result']")));
		return Items.Count > 0;
	}

	public bool ItemNamesContain(string str)
	{
		var trueForAll = true;
		var partialContain = false;

		foreach (var webElement in Items)
		{
			var itemTextContainer = webElement.FindElements(By.XPath(".//h2"));
			if (itemTextContainer.Count==0)
				continue;
			var itemText = itemTextContainer[0].GetAttribute("innerHTML");
			var completeContain = itemText.Contains(str);
			var separates = str.Split(" ");

			foreach (var substr in separates)
			{
				partialContain = str.Contains(substr);
			}

			trueForAll = trueForAll && (completeContain || partialContain);
		}

		return trueForAll;
	}

	public bool PricesWithinRange(string range)
	{
		var lower = 0.0;
		var upper = 0.0;
		var trueForAll = true;
		
		switch (range)
		{
			case "Under $25":
				lower = 0.0;
				upper = 25.0;
				break;
			case"$25 to $50":
				lower = 25.0;
				upper = 50.0;
				break;
			case"$50 to $100":
				lower = 50.0;
				upper = 100.0;
				break;
			case"$100 to $200":
				lower = 100.0;
				upper = 200.0;
				break;
			case"$200 & Above":
				lower = 200.0;
				upper = double.MaxValue;
				break;
		}

		foreach (var item in Items)
		{
			var priceContainer = item.FindElements(By.XPath(".//span[@class='a-offscreen']"));
			if (priceContainer.Count==0)
				continue;
			
			var price = double.Parse(
				priceContainer[0].GetAttribute("innerHTML").Remove(0, 1),
				CultureInfo.InvariantCulture);
			trueForAll = trueForAll && price > lower && price < upper;
		}

		return trueForAll;
	}
}
