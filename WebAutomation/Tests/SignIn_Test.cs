using NUnit.Framework;
using System;
using System.Threading;
using WebAutomation.PageObjects;

namespace WebAutomation
{
    //FIXME: set the browsers that you would like to run the test
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    public class SignIn_Test : BaseTest.Base_Test
    {
        //pass browser to construct the base_test class
        public SignIn_Test(string browser) : base(browser) { }

        //initialize all page object classes that will be used for the test
        Home_PO homePage;
        Authentication_PO authenticationPage;
        CreateAccount_PO createAccountPage;
        MyAccount_PO myAccountPage;

        [Test]
        public void ValidateSuccessfulSignIn()
        {
            /*
             * Open [Home page](http://automationpractice.com/index.php) 
             */
            //invoke home page object
            homePage = new Home_PO(webDriver);

            webDriver.Url = homePage.GetHomeURL();

            /*
             * Click *Sign in* button 
             */
            homePage.ClickOnSignIn();

            /*
             * Fill *Email address* to create an account 
             * And click *Create an account* 
             */
            //invoke authentication page object
            authenticationPage = new Authentication_PO(webDriver);

            authenticationPage.CreateNewAccount();

            /*
             * Fill all fields with correct data
             * And click *Register* button 
             */
            //invoke create account form page object
            createAccountPage = new CreateAccount_PO(webDriver);

            createAccountPage.FillRegistrationForm("Erick", "Cajas", 05, 10, 1996, "Arizona");

            /*
             * Assertions to validate successful sign in
             */
            //invoke my account page object
            myAccountPage = new MyAccount_PO(webDriver);

            string myAccountUrl = myAccountPage.GetMyAccountUrl();
            Boolean logOutIsDisplayed = myAccountPage.LogOutAvailable();
            string getFormFullName = createAccountPage.getFormNameAndLastName;
            string getMyAccountFullName = myAccountPage.GetUserNameText();

            //avoid stop the rest of assertions when one fails
            Assert.Multiple(() =>
            {
                //validate correct url for my account page(?controller=my-account) is opened 
                Assert.That(myAccountUrl, Contains.Substring("?controller=my-account"));

                //validate logout button is available
                Assert.IsTrue(logOutIsDisplayed);

                //validate proper username is shown in the menu bar
                Assert.AreEqual(getFormFullName, getMyAccountFullName);

                //FIXME: sleep added to show my account page
                Thread.Sleep(3000);
            });
        }
    }
}