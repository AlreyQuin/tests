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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected HelperLogin helperLogin;
        protected HelperNavigation helperNavigation;
        protected HelperGroup helperGroup;
        protected HelperContact helperContact;

        public ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";

            verificationErrors = new StringBuilder();
            helperLogin = new HelperLogin(driver);
            helperNavigation = new HelperNavigation(driver, baseURL);
            helperGroup = new HelperGroup(driver);
            helperContact = new HelperContact(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public HelperLogin Logon
        {
            get { return helperLogin; }
        }

        public HelperNavigation Navigation
        {
            get { return helperNavigation; }
        }

        public HelperGroup Groups
        {
            get { return helperGroup; }
        }

        public HelperContact Contacts
        {
            get { return helperContact; }
        }

    }
}
