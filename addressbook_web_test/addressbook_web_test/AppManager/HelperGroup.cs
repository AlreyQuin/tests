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
            manager.Navigation.OpenGroupPage();
            InitCreateGroup();
            FillGroupForm(group);
            SubmitCreateGroup();
            manager.Navigation.OpenGroupPage();
            return this;
        }

        public HelperGroup Delete(int indexGroup)
        {
            manager.Navigation.OpenGroupPage();
            SelectGroup(indexGroup);
            DeleteGroup();
            manager.Navigation.OpenGroupPage();
            return this;
        }

        public HelperGroup Update(int indexGroup, DataGroup newData)
        {
            manager.Navigation.OpenGroupPage();
            SelectGroup(indexGroup);
            EditGroup();
            FillGroupForm(newData);
            UpdateGroup();
            manager.Navigation.OpenGroupPage();
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

        public bool FindGroup()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public HelperGroup FillGroupForm(DataGroup group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
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
