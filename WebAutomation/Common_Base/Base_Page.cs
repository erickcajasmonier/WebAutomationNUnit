﻿using OpenQA.Selenium;
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
        public IWebElement FindElementBy(By element)
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
        public Boolean IsDisplayed(By element)
        {
            if(FindElementBy(element) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //get the text or value from an element
        public string GetText(By element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if (FindElementBy(element).GetAttribute("value") != null)
            {
                //if the element has a value we will return it
                return FindElementBy(element).GetAttribute("value");
            }
            else
            {
                //if the element doesn't have a value we return the text
                return FindElementBy(element).Text;
            }
        }

        //perform a click action to an element
        public void Click(By element)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                FindElementBy(element).Click();
            } catch(Exception)
            {
                try
                {
                    //if element is not visible try to scroll the page to the element
                    PerformScrollToElement(element);
                    FindElementBy(element).Click();
                } catch(Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //send text into an input field
        public void SendKeys(By element, string keys)
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                FindElementBy(element).SendKeys(keys);
            } catch(Exception)
            {
                try
                {
                    //if element is not visible try to scroll the page to the element
                    PerformScrollToElement(element);
                    FindElementBy(element).SendKeys(keys);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //select an item inside a combo box
        public void SelectElementInComboBox(By element, string item)
        {
            try
            {
                //select item if the element match the item with the value
                new SelectElement(FindElementBy(element)).SelectByValue(item);
            } catch(Exception)
            {
                try
                {
                    //select item if the element match the item with the text
                    new SelectElement(FindElementBy(element)).SelectByText(item);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        //generate a random text with letters and numbers
        public string GenerateRandomLetterAndNumbers(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //generate random letters
        public string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //generate random numbers
        public string GenerateRandomInt(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //perform an scroll until an element is visible
        public void PerformScrollToElement(By element) {
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(FindElementBy(element));
            actions.Perform();
        }

        //get the browser url for an specific page
        public string GetBrowserURL()
        {
            return webDriver.Url.ToString();
        }
    }
}
