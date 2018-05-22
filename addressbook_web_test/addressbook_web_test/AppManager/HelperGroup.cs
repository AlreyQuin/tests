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

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }

        private List<DataGroup> groupCache = null;

        public List<DataGroup> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<DataGroup>();
                manager.Navigation.OpenGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new DataGroup(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<DataGroup>(groupCache);
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
            groupCache = null;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (indexGroup+1) + "]")).Click();
            return this;
        }

        public HelperGroup DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }
        
    }
}
