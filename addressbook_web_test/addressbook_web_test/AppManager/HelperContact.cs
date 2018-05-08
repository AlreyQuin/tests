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

        public HelperContact(ApplicationManager manager) 
            : base(manager)
        {}



        public HelperContact New(DataNewUser data)
        {
            CreateNewUser();
            FillUserForm(data);
            AcceptCreateUser();
            manager.Navigation.GoToHomePage();
            return this;
        }

        public HelperContact Delete(int v)
        {
            manager.Navigation.GoToHomePage();
            CheckDeleteUser(v);
            ClickDelete();
            AcceptDelete();
            return this;
        }

        public HelperContact Update(DataNewUser userData, int indexEdit)
        {
            manager.Navigation.GoToHomePage();
            EditUser(indexEdit);
            UpdateForm(userData);
            UpdateUser();
            manager.Navigation.GoToHomePage();
            return this;
        }

        public HelperContact CreateNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public HelperContact FillUserForm(DataNewUser data)
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
            return this;
        }


        public HelperContact UpdateForm(DataNewUser update)
        {
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(update.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(update.Mobile);

            return this;
        }

        public HelperContact AcceptCreateUser()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            return this;
        }

        public HelperContact EditUser(int indexEdit)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + indexEdit + "]")).Click();
            return this;
        }

        public HelperContact UpdateUser()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public HelperContact CheckDeleteUser(int indexDel)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + indexDel + "]")).Click();
            return this;
        }

        public HelperContact ClickDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        /*      public HelperContact AcceptDelete()
              {
                  Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
                  return this;
              } */

        public HelperContact AcceptDelete()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
