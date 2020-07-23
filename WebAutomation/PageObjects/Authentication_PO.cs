using OpenQA.Selenium;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    class Authentication_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public Authentication_PO(IWebDriver webDriver) : base(webDriver)
        {
        }

        private By emailAddressCreateTextBox = By.Id("email_create");
        private By createAccountButton = By.Id("SubmitCreate");

        public void createNewAccount()
        {
            typeEmailAddress();
            clickOnCreateAccount();
        }

        public void typeEmailAddress()
        {
            sendKeys(emailAddressCreateTextBox, generateRandomLetterAndNumbers(6) + "@hotmail.com");
        }

        public void clickOnCreateAccount() {
            click(createAccountButton);
        }
    }
}
