using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject.Specs.Pages;

namespace SpecFlowProject.Specs.Steps;

[Binding]
public sealed class StepDefinitions
{
	// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
	private readonly ScenarioContext _scenarioContext;
	private IWebDriver _driver;
	private Cart _cart;
	private Catalogue _catalogue;
	private Header _header;
	private HomePage _homepage;
	private ItemPage _itempage;
	private Login _login;
	private Hooks.Hooks _hooks;
	private double oldPrice = Double.MinValue;
	private int oldQuantity = Int32.MinValue;
	private int oldItemAmount = Int32.MinValue;

	public StepDefinitions(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;
		_driver = new ChromeDriver();
		_driver.Manage().Window.Maximize();
		_cart = new Cart(_driver);
		_catalogue = new Catalogue(_driver);
		_header = new Header(_driver);
		_homepage = new HomePage(_driver);
		_itempage = new ItemPage(_driver);
		_login = new Login(_driver);
		_hooks = new Hooks.Hooks(_driver);
	}

	[Given(@"user is on (.*)")]
	public void GivenUserIsOn(string pageUrl)
	{
		switch (pageUrl)
		{
			case "cart":
				Cart.GoTo();

				break;
			case "Login":
				Login.GoTo();

				break;
			case "home page":
				HomePage.GoTo();

				break;
			default:
				_driver.Navigate().GoToUrl(pageUrl);

				break;
		}
	}

	[When(@"(.*) is clicked")]
	public void WhenIsClicked(string p0)
	{
		switch (p0)
		{
			case "quantity dropdown":
				oldQuantity = _cart.GetQuantity();
				oldPrice = _cart.GetDisplayedSubtotal();
				_cart.ClickQuantityDropDown();

				break;
			case "delete":
				oldItemAmount = _cart.GetItemCount();
				oldPrice = _cart.GetDisplayedSubtotal();
				_cart.DeleteItem();

				break;
			case "proceed to checkout":
				_cart.ProceedToCheckout();

				break;
			case "add to cart":
				_itempage.AddToCart();

				break;
			case "add to list":
				_itempage.AddToList();

				break;
			case "buy now":
				_itempage.BuyNow();

				break;
			default:
				break;
		}
	}

	[Then(@"displayed item prices are within (.*)")]
	public void ThenDisplayedItemPricesAreWithin(string p0)
	{
		ScenarioContext.StepIsPending();
	}

	[Then(@"user is redirected to order processing")]
	public void ThenUserIsRedirectedToOrderProcessing()
	{
		var expected = @"https://www.amazon.com/gp/buy/addressselect/handlers/display.html?hasWorkingJavascript=1";
		Assert.AreEqual(expected, _driver.Url);
	}

	[When(@"(.*) is entered in search field")]
	public void WhenIsEnteredInSearchField(string query)
	{
		_header.Search(query);
	}

	[Then(@"items are shown on catalogue page")]
	public void ThenItemsAreShownOnCataloguePage()
	{
		ScenarioContext.StepIsPending();
	}

	[Then(@"item names contain (.*)")]
	public void ThenItemNamesContain(string query)
	{
		ScenarioContext.StepIsPending();
	}

	[Given(@"items are in cart")]
	public void GivenItemsAreInCart()
	{
		_cart.AreItemsInCart();
	}

	[Then(@"subtotal is recalculated")]
	public void ThenSubtotalIsRecalculated()
	{
		Assert.AreNotEqual(oldPrice, _cart.GetDisplayedSubtotal());
		Assert.AreEqual(_cart.CalculateSubtotal(), _cart.GetDisplayedSubtotal());
	}

	[When(@"value from dropdown is selected")]
	public void WhenValueFromDropdownIsSelected()
	{
		_cart.SelectValueInDropdown();
	}

	[Then(@"selected item quantity is changed")]
	public void ThenSelectedItemQuantityIsChanged()
	{
		Assert.AreNotEqual(oldQuantity, _cart.GetQuantity());
	}

	[Then(@"item is removed from cart")]
	public void ThenItemIsRemovedFromCart()
	{
		Assert.AreNotEqual(oldItemAmount, _cart.GetItemCount());
	}

	[Given(@"item is in stock")]
	public void GivenItemIsInStock()
	{
		if (!_itempage.IsInStock())
			ScenarioContext.StepIsPending();
	}

	[Then(@"item is added to cart")]
	public void ThenItemIsAddedToCart()
	{
		Assert.True(_itempage.AddToCartIsSuccessful());
	}

	[Then(@"cart subtotal is shown")]
	public void ThenCartSubtotalIsShown()
	{
		Assert.True(_itempage.SubtotalIsDisplayed());
	}

	[Given(@"user has shopping list")]
	public void GivenUserHasShoppingList()
	{
		if (!_itempage.ListExists())
			_itempage.CreateList();
		Assert.True(_itempage.ListExists());
	}

	[Then(@"item is added to list")]
	public void ThenItemIsAddedToList()
	{
		Assert.True(_itempage.AddToListIsSuccessful());
	}

	[Then(@"login is Successful")]
	public void ThenLoginIsSuccessful()
	{
		Assert.True(_header.UserIsLoggedIn());
	}

	[Then(@"login is Unsuccessful")]
	public void ThenLoginIsUnsuccessful()
	{
		Assert.True(_login.ErrorWhileLoggingIn());
	}

	[When(@"(.*) is entered as username")]
	public void WhenIsEnteredAsUsername(string p0)
	{
		_login.InputEmail(p0);
	}

	[When(@"(.*) is entered as password")]
	public void WhenIsEnteredAsPassword(string p0)
	{
		_login.InputPassword(p0);
	}

	[Given(@"user is logged in")]
	public void GivenUserIsLoggedIn()
	{
		if (!_header.UserIsLoggedIn())
		{
			_header.GoToLogin();
			_login.PerformLogin(validEmail, validPassword);
		}

		Assert.True(_header.UserIsLoggedIn());
	}

	private const string validEmail = "olenkashipka@gmail.com";
	private const string validPassword = "VeryStrongPassword";

	[Given(@"delivering to (.*)")]
	public void GivenDeliveringTo(string country)
	{
		if(_header.GetCurrentDeliveryCountry()!=country)
			_header.TrySwitchTo(country);
	}
	
}
