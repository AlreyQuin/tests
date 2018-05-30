using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace AddressbookWebTest
{
    public class HelperContact : HelperBase
    {

        public HelperContact(ApplicationManager manager) 
            : base(manager)
        {}



        public HelperContact New(DataNewContact data)
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

        public HelperContact Update(DataNewContact userData, int indexEdit)
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

        private List<DataNewContact> contactCache = null;

        public string Last { get; private set; }

        public List<DataNewContact> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<DataNewContact>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> strs = driver.FindElements(By.Name("entry"));
                foreach (IWebElement str in strs)
                {
                    var cells = str.FindElements(By.TagName("td")).ToArray();
                    contactCache.Add(new DataNewContact(cells[2].Text, cells[1].Text)
                    {
                        Id = str.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<DataNewContact>(contactCache);
        }

        public DataNewContact GetContactInfoFromTable(int index)
        {
            manager.Navigation.GoToHomePage();
            EditUser(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new DataNewContact(firstname, lastname)
            {
                Middlename = middlename,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Homepage = homepage,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }

        public DataNewContact GetContactInfoFromForm(int index)
        {
            manager.Navigation.GoToHomePage();
            IList<IWebElement> contactsFromForm = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string firstname = contactsFromForm[2].Text;
            string lastname = contactsFromForm[1].Text;
            string address = contactsFromForm[3].Text;
            string allEmails = contactsFromForm[4].Text;
            string allPhones = contactsFromForm[5].Text;

            return new DataNewContact(firstname, lastname)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        internal DataNewContact GetContactInfoFromDetails(int index)
        {
            manager.Navigation.GoToHomePage();
            DetailsUser(index);
            IList<IWebElement> contactsFromName = driver.FindElements(By.CssSelector("div#content b"));
            string fullname = contactsFromName[0].Text;
            string[] allName = fullname.Split();
            string firstname = allName[0].Trim();
            string lastname = allName[2].Trim();
            IList<IWebElement> contactsFromDetails = driver.FindElements(By.CssSelector("div#content"));
            string allDataContact = contactsFromDetails[0].Text;

            return new DataNewContact(firstname, lastname)
            {
                FullData = allDataContact
            };

        }

        public HelperContact CreateNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public HelperContact FillUserForm(DataNewContact data)
        {
            Type(By.Name("firstname"), data.Firstname);
            Type(By.Name("middlename"), data.Middlename);
            Type(By.Name("lastname"), data.Lastname);
            Type(By.Name("nickname"), data.Nickname);
            Type(By.Name("company"), data.Company);
            Type(By.Name("address"), data.Address);
            return this;
        }


        public HelperContact UpdateForm(DataNewContact update)
        {
            Type(By.Name("firstname"), update.Firstname);
            Type(By.Name("lastname"), update.Lastname);
            Type(By.Name("home"), update.HomePhone);
            Type(By.Name("mobile"), update.MobilePhone);
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
            driver.FindElements(By.Name("entry"))[indexEdit]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public HelperContact DetailsUser(int indexEdit)
        {
            driver.FindElements(By.Name("entry"))[indexEdit]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
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

        public int GetNumberOfSearchResults()
        {
            manager.Navigation.GoToHomePage();
            string lable = driver.FindElement(By.TagName("lable")).Text;
            Match m = new Regex(@"\d+").Match(lable);
            return Int32.Parse(m.Value);
        }
    }
}
