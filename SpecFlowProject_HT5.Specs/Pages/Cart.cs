using System.Collections.ObjectModel;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Specs.Pages;

public class Cart
{
	private static IWebDriver Driver { get; set; }
	private WebDriverWait _wait;

	private IWebElement ProceedToCheckoutButton => Driver.FindElement(By.CssSelector("#sc-buy-box-ptc-button > span > input"));
	private ReadOnlyCollection<IWebElement> QuantityDropdowns => Driver.FindElements(By.XPath("//*[@data-action='a-dropdown-button']/.."));
	private ReadOnlyCollection<IWebElement> QuantityDropdownValues => Driver.FindElements(By.XPath("//li[contains(@role, 'option')]"));
	private ReadOnlyCollection<IWebElement> DeleteButtons => Driver.FindElements(By.XPath("//input[contains(@name, 'delete')]"));
	private ReadOnlyCollection<IWebElement> ItemsInCart => Driver.FindElements(By.XPath("//div[contains(@class, 'sc-list-item ')]"));
	private IWebElement Subtotal => Driver.FindElement(By.CssSelector("#sc-subtotal-amount-buybox > span"));
	
	public Cart(IWebDriver driver)
	{
		Driver = driver;
		_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
	}
	
	public static void GoTo()
	{
		Driver.Navigate().GoToUrl(@"https://www.amazon.com/gp/cart/view.html?ref_=nav_cart");
	}

	public bool AreItemsInCart()
	{
		return ItemsInCart.Count > 0;
	}

	private int GetQuantityFromItem(IWebElement item)
	{
Console.WriteLine($"Quantity: {int.Parse(item.GetAttribute("data-quantity"))}");
		
		return int.Parse(item.GetAttribute("data-quantity"));
	}
	
	public int GetQuantity(int itemNumber = 0)
	{
		return GetQuantityFromItem(ItemsInCart[itemNumber]);
	}

	private double GetPriceFromItem(IWebElement item)
	{

		Console.WriteLine(
			$"Price: {double.Parse(item.GetAttribute("data-price"), NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture)}");
		return double.Parse(item.GetAttribute("data-price"), NumberStyles.AllowDecimalPoint|NumberStyles
		.AllowCurrencySymbol, CultureInfo
		.InvariantCulture);
	}

	public double GetDisplayedSubtotal()
	{
		return double.Parse(Subtotal.GetAttribute("innerHTML").Remove(0, 1), NumberStyles
		.AllowDecimalPoint|NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture);
	}

	public double CalculateSubtotal()
	{
		return ItemsInCart.Sum(item => GetPriceFromItem(item) * GetQuantityFromItem(item));
	}

	public void ProceedToCheckout()
	{
		ProceedToCheckoutButton.Click();
	}

	public void DeleteItem(int itemNumber = 0)
	{
		DeleteButtons[itemNumber].Click();
		Driver.Navigate().Refresh();
	}

	public void ClickQuantityDropDown(int itemNumber = 0)
	{
		QuantityDropdowns[itemNumber].Click();
	}

	public void SelectValueInDropdown(int valueNumber = 3, int itemNumber =0)
	{
		QuantityDropdownValues[valueNumber].Click();
		Driver.Navigate().Refresh();
	}

	public int GetItemCount()
	{
		return ItemsInCart.Count;
	}
}
