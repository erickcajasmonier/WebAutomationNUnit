using NUnit.Framework;
using System;
using WebAutomation.PageObjects;

namespace WebAutomation
{
    internal class SignIn_Test : BaseTest.Base_Test
    {
        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        Authentication_PO authenticationPage;
        CreateAccount_PO createAccountPage;
        MyAccount_PO myAccountPage;

        [Test, Order(1)]
        public void OpenHomePage()
        {
            //invoke home page object
            homePage = new Home_PO(webDriver);

            webDriver.Url = homePage.getHomeURL();
            Assert.Pass();
        }

        [Test, Order(2)]
        public void OpenSignInPage()
        {
            homePage.clickOnSignIn();
            Assert.Pass();
        }

        [Test, Order(3)]
        public void CreateNewAccount()
        {
            //invoke authentication page object
            authenticationPage = new Authentication_PO(webDriver);

            authenticationPage.createNewAccount();
            Assert.Pass();
        }

        [Test, Order(4)]
        public void FillNewUserInfoForm()
        {
            //invoke create account form page object
            createAccountPage = new CreateAccount_PO(webDriver);

            createAccountPage.fillRegistrationForm("Erick", "Cajas", "5", "10", "1996", "Arizona");
            Assert.Pass();
        }

        [Test, Order(5)]
        public void ValidateSuccessfulSignIn()
        {
            //invoke my account page object
            myAccountPage = new MyAccount_PO(webDriver);

            string myAccountUrl = myAccountPage.getMyAccountUrl();
            Boolean logOutIsDisplayed = myAccountPage.logOutAvailable();
            string getFormFullName = createAccountPage.getFormNameAndLastName;
            string getMyAccountFullName = myAccountPage.getUserNameText();

            //avoid stop the rest of assertions when one fails
            Assert.Multiple(() =>
            {
                //validate correct url for my account page
                Assert.That(myAccountUrl, Contains.Substring("?controller=my-account"));

                //validate logout button is available
                Assert.IsTrue(logOutIsDisplayed);

                //validate correct user name
                Assert.AreEqual(getMyAccountFullName, getFormFullName);
            });
        }
    }
}