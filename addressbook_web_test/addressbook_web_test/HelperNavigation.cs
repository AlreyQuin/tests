using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AddressbookWebTest
{
    public class HelperNavigation : HelperBase
    {
        private string baseURL;

        public HelperNavigation(IWebDriver driver, string baseURL) 
            : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

    }
}
