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

        public HelperGroup(IWebDriver driver) 
            : base(driver)
        {}


        public void InitCreateGroup()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void SubmitCreateGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void FillGroupForm(DataGroup group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void SelectGroup(int indexGroup)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + indexGroup + "]")).Click();
        }

        public void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
    }
}
