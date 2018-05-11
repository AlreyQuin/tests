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

        public HelperNavigation(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "addressbook/"
                && IsElementPresent(By.XPath("//input[@value='Delete']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void OpenGroupPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
