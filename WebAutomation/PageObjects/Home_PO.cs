using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class Home_PO : Base_Page
    {        
        //pass driver to construct the base_page class
        public Home_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By signInButton = By.ClassName("login");
        private string homeUrl = "http://automationpractice.com/index.php";
        
        public String GetHomeURL() {
            return homeUrl;
        }
        
        public void ClickOnSignIn()
        {
            Click(signInButton);
        }
    }
}
