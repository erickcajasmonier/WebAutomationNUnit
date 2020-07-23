using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class MyAccount_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public MyAccount_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By userNameLabel = By.ClassName("account");
        private By logOutButton = By.ClassName("logout");

        public string getUserNameText()
        {
            return getText(userNameLabel);
        }

        public Boolean logOutAvailable()
        {
            return isDisplayed(logOutButton);
        }

        public string getMyAccountUrl()
        {
            return getBrowserURL();
        }

    }
}
