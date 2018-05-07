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
            OpenPage();
            Login(new DataAccount("admin", "secret"));
            OpenGroupPage();
            SelectGroup(1);
            DeleteGroup();
            OpenPage();
        }
    }
}

