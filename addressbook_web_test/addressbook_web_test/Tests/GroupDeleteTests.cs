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
            app.Navigation.OpenPage();
            app.Logon.Login(new DataAccount("admin", "secret"));
            app.Navigation.OpenGroupPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroup();
            app.Navigation.OpenPage();
        }
    }
}

