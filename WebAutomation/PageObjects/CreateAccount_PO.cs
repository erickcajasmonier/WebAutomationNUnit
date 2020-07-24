using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WebAutomation.BaseTest;

namespace WebAutomation.PageObjects
{
    public class CreateAccount_PO : Base_Page
    {
        //pass driver to construct the base_page class
        public CreateAccount_PO(RemoteWebDriver webDriver) : base(webDriver) { }

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

        public void FillRegistrationForm(
            string firstName, string lastName, 
            int day, int month,
            int year, string state)
        {
            ClickOnMr();
            TypeFirstName(firstName);
            TypeLastName(lastName);
            getFormNameAndLastName = GetFirstName() + " " + GetLastName();
            TypePassword();
            SelectDateOfBirth(day, month, year);
            TypeCompany();
            ClickOnNewsLetter();
            ClickOnOptIn();
            TypeAddress1();
            TypeAddress2();
            TypeCity();
            TypePostalCode();
            SelectState(state);
            TypeAdditionalInfo();
            TypeHomePhone();
            TypeMobilePhone();
            ClickOnRegister();
        }

        public void ClickOnMr()
        {
            Click(mrRadioButton);
        }

        public void TypeFirstName(string firstName)
        {
            SendKeys(firstNameTextBox, firstName);
        }

        public string GetFirstName()
        {
            return GetText(firstNameTextBox);
        }

        public void TypeLastName(string lastName)
        {
            SendKeys(lastNameTextBox, lastName);
        }

        public string GetLastName()
        {
            return GetText(lastNameTextBox);
        }

        public void TypePassword()
        {
            SendKeys(passwordTextBox, GenerateRandomLetterAndNumbers(5));
        }

        public void SelectDateOfBirth(int day, int month, int year) {
            SelectDayOfBirth(day.ToString());
            SelectMonthOfBirth(month.ToString());
            SelectYearOfBirth(year.ToString());
        }

        public void ClickOnNewsLetter()
        {
            Click(newsLetterCheckBox);
        }

        public void ClickOnOptIn()
        {
            Click(optInCheckBox);
        }

        public void TypeCompany()
        {
            SendKeys(companyTextBox, GenerateRandomString(5));
        }

        public void TypeAddress1()
        {
            SendKeys(address1TextBox, GenerateRandomString(13));
        }

        public void TypeAddress2()
        {
            SendKeys(address2TextBox, GenerateRandomString(7));
        }

        public void TypeCity()
        {
            SendKeys(cityTextBox, GenerateRandomString(5));
        }

        public void SelectState(string state)
        {
            SelectElementInComboBox(stateComboBox, state);
        }

        public void TypePostalCode()
        {
            SendKeys(postalCodeTextBox, GenerateRandomInt(5));
        }

        public void TypeAdditionalInfo()
        {
            SendKeys(additionalInfoTextBox, GenerateRandomLetterAndNumbers(25));
        }

        public void TypeHomePhone()
        {
            SendKeys(homePhoneTextBox, GenerateRandomInt(7));
        }

        public void TypeMobilePhone()
        {
            SendKeys(mobilePhoneTextBox, GenerateRandomInt(9));
        }

        public void ClickOnRegister()
        {
            Click(registerButton);
        }

        public void SelectDayOfBirth(string day) {
            SelectElementInComboBox(dayOfBirthComboBox, day);
        }

        public void SelectMonthOfBirth(string month)
        {
            SelectElementInComboBox(monthOfBirthComboBox, month);
        }

        public void SelectYearOfBirth(string year)
        {
            SelectElementInComboBox(yearOfBirthComboBox, year);
        }


    }
}
