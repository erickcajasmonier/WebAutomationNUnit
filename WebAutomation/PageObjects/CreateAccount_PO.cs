using OpenQA.Selenium;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class CreateAccount_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public CreateAccount_PO(IWebDriver webDriver) : base(webDriver)
        {
        }

        private By mrRadioButton = By.Id("uniform-id_gender1");
        private By firstNameTextBox = By.Id("customer_firstname");
        private By lastNameTextBox = By.Id("customer_lastname");
        private By passwordTextBox = By.Id("passwd");
        private By dayOfBirthComboBox = By.Id("days");
        private By monthOfBirthComboBox = By.Id("months");
        private By yearOfBirthComboBox = By.Id("years");
        private By newsLetterCheckBox = By.Id("newsletter");
        private By optInCheckBox = By.Id("optin");
        private By companyTextBox = By.Id("company"); 
        private By address1TextBox = By.Id("address1");
        private By address2TextBox = By.Id("address2");
        private By cityTextBox = By.Id("city");
        private By stateComboBox = By.Id("id_state");
        private By postalCodeTextBox = By.Id("postcode");
        private By additionalInfoTextBox = By.Id("other");
        private By homePhoneTextBox = By.Id("phone");
        private By mobilePhoneTextBox = By.Id("phone_mobile");
        private By registerButton = By.Id("submitAccount");
        public string getFormNameAndLastName = null;

        public void fillRegistrationForm(
            string firstName, string lastName, 
            string day, string month,
            string year, string state)
        {
            clickOnMr();
            typeFirstName(firstName);
            typeLastName(lastName);
            getFormNameAndLastName = getFirstName() + " " + getLastName();
            typePassword();
            selectDateOfBirth(day, month, year);
            clickOnNewsLetter();
            clickOnOptIn();
            typeCompany();
            typeAddress1();
            typeAddress2();
            typeCity();
            selectState(state);
            typePostalCode();
            typeAdditionalInfo();
            typeHomePhone();
            typeMobilePhone();
            clickOnRegister();
        }

        public void clickOnMr()
        {
            click(mrRadioButton);
        }

        public void typeFirstName(string firstName)
        {
            sendKeys(firstNameTextBox, firstName);
        }

        public string getFirstName()
        {
            return getText(firstNameTextBox);
        }

        public void typeLastName(string lastName)
        {
            sendKeys(lastNameTextBox, lastName);
        }

        public string getLastName()
        {
            return getText(lastNameTextBox);
        }

        public void typePassword()
        {
            sendKeys(passwordTextBox, generateRandomLetterAndNumbers(5));
        }

        public void selectDateOfBirth(string day, string month, string year) {
            selectDayOfBirth(day);
            selectMonthOfBirth(month);
            selectYearOfBirth(year);
        }

        public void clickOnNewsLetter()
        {
            click(newsLetterCheckBox);
        }

        public void clickOnOptIn()
        {
            click(optInCheckBox);
        }

        public void typeCompany()
        {
            sendKeys(companyTextBox, generateRandomString(5));
        }

        public void typeAddress1()
        {
            sendKeys(address1TextBox, generateRandomString(13));
        }

        public void typeAddress2()
        {
            sendKeys(address2TextBox, generateRandomString(7));
        }

        public void typeCity()
        {
            sendKeys(cityTextBox, generateRandomString(5));
        }

        public void selectState(string state)
        {
            sendKeys(stateComboBox, state);
        }

        public void typePostalCode()
        {
            sendKeys(postalCodeTextBox, generateRandomInt(5));
        }

        public void typeAdditionalInfo()
        {
            sendKeys(additionalInfoTextBox, generateRandomLetterAndNumbers(25));
        }

        public void typeHomePhone()
        {
            sendKeys(homePhoneTextBox, generateRandomInt(7));
        }

        public void typeMobilePhone()
        {
            sendKeys(mobilePhoneTextBox, generateRandomInt(9));
        }

        public void clickOnRegister()
        {
            click(registerButton);
        }

        public void selectDayOfBirth(string day) {
            selectElementInComboBox(dayOfBirthComboBox, day);
        }

        public void selectMonthOfBirth(string month)
        {
            selectElementInComboBox(monthOfBirthComboBox, month);
        }

        public void selectYearOfBirth(string year)
        {
            selectElementInComboBox(yearOfBirthComboBox, year);
        }


    }
}
