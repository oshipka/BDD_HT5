using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject.Specs.Pages;

public class ItemPage
{
	private IWebDriver Driver { get; set; }
	private WebDriverWait _wait;
	private IWebElement Availability => Driver.FindElement(By.CssSelector("#availability > span"));
	private IWebElement SuccessMsg => Driver.FindElement(By.CssSelector("#NATC_SMART_WAGON_CONF_MSG_SUCCESS > span"));
	private IWebElement CartSubtotal =>
		Driver.FindElement(By.CssSelector("#sw-subtotal > span:nth-child(2) > span > span.a-offscreen"));
	private IWebElement AddToCartBtn => Driver.FindElement(By.CssSelector("#add-to-cart-button"));
	private IWebElement AddToListBtn => Driver.FindElement(By.CssSelector("#add-to-wishlist-button-submit"));
	private IWebElement BuyNowBtn => Driver.FindElement(By.CssSelector("#buy-now-button"));
	private ReadOnlyCollection<IWebElement> Lists => Driver.FindElements(By.CssSelector("#add-to-wishlist-button"));

	private IWebElement ListSuccess =>
		Driver.FindElement(
			By.CssSelector("#huc-atwl-header-section > div > span.a-size-medium-plus.huc-atwl-header-main"));
	public ItemPage(IWebDriver driver)
	{
		Driver = driver;
		_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
	}

	public bool IsInStock()
	{
		return Availability.GetAttribute("innerHTML") == "    In Stock.   ";
	}
	public bool AddToCartIsSuccessful()
	{
		_wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#NATC_SMART_WAGON_CONF_MSG_SUCCESS > span")));
		return SuccessMsg.GetAttribute("innerHTML") == "\r\nAdded to Cart\r\n";
	}

	public bool AddToListIsSuccessful()
	{
		_wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#huc-atwl-header-section > div > span.a-size-medium-plus.huc-atwl-header-main")));
		return ListSuccess.GetAttribute("innerHTML") == "1 item added to" ||
		       ListSuccess.GetAttribute("innerHTML") == "This item was already in";
	}
	
	public bool SubtotalIsDisplayed()
	{
		return CartSubtotal.GetAttribute("innerHTML") != "";
	}

	public bool ListExists()
	{
		return Lists.Count > 0;
	}
	
	public void CreateList(){}

	public void AddToCart()
	{
		AddToCartBtn.Click();
	}

	public void AddToList()
	{
		AddToListBtn.Click();
	}

	public void BuyNow()
	{
		BuyNowBtn.Click();
	}
	
}
