using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace WebAutomation.BaseTest
{
    public class Base_Page
    {
        protected RemoteWebDriver webDriver;
        protected WebDriverWait wait;
        protected Random random = new Random();

        public Base_Page(RemoteWebDriver driver) {
            webDriver = driver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(2));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        //find element by their respective indicators
        public IWebElement findElementBy(By element)
        {
            try
            {
                return webDriver.FindElement(element);
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //check if an element is being displayed
        public Boolean isDisplayed(By element)
        {
            if(findElementBy(element) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get the text or value from an element
        public string getText(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if (findElementBy(element).GetAttribute("value") != null)
            {
                //if the element has a value we will return it
                return findElementBy(element).GetAttribute("value");
            }
            else
            {
                //if the element doesn't have a value we return the text
                return findElementBy(element).Text;
            }
        }

        //perform a click action to an element
        public void click(By element)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                findElementBy(element).Click();
            } catch(Exception)
            {
                try
                {
                    //If element is not visible try to scroll the page to the element
                    performScrollToElement(element);
                    findElementBy(element).Click();
                } catch(Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //send text into an input field
        public void sendKeys(By element, string keys)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                findElementBy(element).SendKeys(keys);
            } catch(Exception)
            {
                try
                {
                    //If element is not visible try to scroll the page to the element
                    performScrollToElement(element);
                    findElementBy(element).SendKeys(keys);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //select an item inside a combo box
        public void selectElementInComboBox(By element, string item)
        {
            try
            {
                //select item if the element match the item with the value
                new SelectElement(findElementBy(element)).SelectByValue(item);
            } catch(Exception)
            {
                try
                {
                    //select item if the element match the item with the text
                    new SelectElement(findElementBy(element)).SelectByText(item);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //Generate a random text with letters and numbers
        public string generateRandomLetterAndNumbers(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Generate random letters
        public string generateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Generate random numbers
        public string generateRandomInt(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //perform an scroll until an element is visible
        public void performScrollToElement(By element) {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(findElementBy(element));
            actions.Perform();
        }

        //get the browser url for an specific page
        public string getBrowserURL()
        {
            return webDriver.Url.ToString();
        }
    }
}
