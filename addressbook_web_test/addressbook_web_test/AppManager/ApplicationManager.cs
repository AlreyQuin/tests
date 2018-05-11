using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";

            verificationErrors = new StringBuilder();
            helperLogin = new HelperLogin(this);
            helperNavigation = new HelperNavigation(this, baseURL);
            helperGroup = new HelperGroup(this);
            helperContact = new HelperContact(this);
        }

        ~ApplicationManager()
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


        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenPage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            { return driver; }
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
