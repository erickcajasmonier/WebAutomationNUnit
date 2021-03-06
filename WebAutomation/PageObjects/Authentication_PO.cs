﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    class Authentication_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public Authentication_PO(RemoteWebDriver webDriver) : base(webDriver) { }

        private By emailAddressCreateTextBox = By.Id("email_create");
        private By createAccountButton = By.Id("SubmitCreate");

        public void CreateNewAccount()
        {
            TypeEmailAddress();
            ClickOnCreateAccount();
        }

        public void TypeEmailAddress()
        {
            SendKeys(emailAddressCreateTextBox, GenerateRandomLetterAndNumbers(6) + "@hotmail.com");
        }

        public void ClickOnCreateAccount() {
            Click(createAccountButton);
        }
    }
}
