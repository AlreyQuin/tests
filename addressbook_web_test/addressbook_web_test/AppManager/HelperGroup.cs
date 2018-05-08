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
    public class HelperGroup : HelperBase
    {
        public HelperGroup(ApplicationManager manager) 
            : base(manager)
        {}

        public HelperGroup Create(DataGroup group)
        {
            OpenGroupPage();
            InitCreateGroup();
            FillGroupForm(group);
            SubmitCreateGroup();
            OpenGroupPage();
            return this;
        }

        public HelperGroup Delete(int indexGroup)
        {
            OpenGroupPage();
            SelectGroup(indexGroup);
            DeleteGroup();
            OpenGroupPage();
            return this;
        }

        public HelperGroup Update(int indexGroup, DataGroup newData)
        {
            OpenGroupPage();
            SelectGroup(indexGroup);
            EditGroup();
            FillGroupForm(newData);
            UpdateGroup();
            OpenGroupPage();
            return this;
        }

        public HelperGroup OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public HelperGroup InitCreateGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public HelperGroup SubmitCreateGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public HelperGroup FillGroupForm(DataGroup group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public HelperGroup SelectGroup(int indexGroup)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + indexGroup + "]")).Click();
            return this;
        }

        public HelperGroup DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public HelperGroup EditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public HelperGroup UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        
    }
}
