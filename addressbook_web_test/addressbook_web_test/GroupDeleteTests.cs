using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupDeleteTest : BaseClassTest
    {
       
        [Test]
        public void DeleteGroupTest()
        {
            helperNavigation.OpenPage();
            helperLogin.Login(new DataAccount("admin", "secret"));
            helperNavigation.OpenGroupPage();
            helperGroup.SelectGroup(1);
            helperGroup.DeleteGroup();
            helperNavigation.OpenPage();
        }
    }
}

