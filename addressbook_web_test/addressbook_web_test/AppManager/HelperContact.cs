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

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count();
        }

        private List<DataNewUser> contactCache = null;

        public string Last { get; private set; }

        public List<DataNewUser> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<DataNewUser>();
                List<DataNewUser> contacts = new List<DataNewUser>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> strs = driver.FindElements(By.Name("entry"));
                foreach (IWebElement str in strs)
                {
                    var cells = str.FindElements(By.TagName("td")).ToArray();
                    contacts.Add(new DataNewUser(cells[2].Text, cells[1].Text));
                    contactCache.Add(new DataNewUser(cells[2].Text, cells[1].Text)
                    {
                        Id = str.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                return contacts;
            }
            return new List<DataNewUser>(contactCache);
        }

        public HelperContact CreateNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public HelperContact FillUserForm(DataNewUser data)
        {
            Type(By.Name("firstname"), data.Firstname);
            Type(By.Name("middlename"), data.Middlename);
            Type(By.Name("lastname"), data.Lastname);
            Type(By.Name("nickname"), data.Nickname);
            Type(By.Name("company"), data.Company);
            Type(By.Name("address"), data.Address);
            return this;
        }


        public HelperContact UpdateForm(DataNewUser update)
        {
            Type(By.Name("firstname"), update.Firstname);
            Type(By.Name("lastname"), update.Lastname);
            Type(By.Name("home"), update.Home);
            Type(By.Name("mobile"), update.Mobile);
            return this;
        }

        public HelperContact AcceptCreateUser()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
            return this;
        }

        public HelperContact EditUser(int indexEdit)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (indexEdit+1) + "]")).Click();
            return this;
        }

        public HelperContact UpdateUser()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public HelperContact CheckDeleteUser(int indexDel)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (indexDel+1) + "]")).Click();
            return this;
        }

        public HelperContact ClickDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public HelperContact AcceptDelete()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public bool FindUser()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
    }
}
