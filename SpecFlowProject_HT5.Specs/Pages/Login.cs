using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium;

namespace SpecFlowProject.Specs.Pages;

public class Login
{
	private const string LOGIN_URL = @"https://www.amazon.com/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2Fref%3Dnav_ya_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&";
	private IWebElement EmailInput => Driver.FindElement(By.CssSelector("#ap_email"));
	private IWebElement PasswordInput => Driver.FindElement(By.CssSelector("#ap_password"));
	private IWebElement Error => Driver.FindElement(By.CssSelector("#auth-error-message-box > div > h4"));
	private static IWebDriver Driver { get; set; }
	public Login(IWebDriver driver)
	{
		Driver = driver;
	}

	public void InputEmail(string email)
	{
		EmailInput.SendKeys(email);
		EmailInput.Submit();
	}

	public void InputPassword(string password)
	{
		PasswordInput.SendKeys(password);
		PasswordInput.Submit();
	}

	public void PerformLogin(string validEmail, string validPassword)
	{
		InputEmail(validEmail);
		InputPassword(validPassword);
	}

	public bool ErrorWhileLoggingIn()
	{
		return Error.GetAttribute("innerHTML") == "There was a problem";
	}

	public static void GoTo()
	{
		Driver.Navigate().GoToUrl(LOGIN_URL);
	}
}
