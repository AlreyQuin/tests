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
    public class HelperContact : HelperBase
    {

        public HelperContact(IWebDriver driver) 
            : base(driver)
        {}

        public void CreateNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillUserForm(DataNewUser data)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(data.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(data.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(data.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(data.Nickname);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(data.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(data.Address);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(data.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(data.Bmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1963");
        }

        public void AcceptCreateUser()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
        }
    }
}
