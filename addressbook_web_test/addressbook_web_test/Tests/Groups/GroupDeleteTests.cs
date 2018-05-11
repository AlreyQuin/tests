using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupDeleteTest : AuthBaseClassTest
    {
       
        [Test]
        public void DeleteGroupTest()
        {
            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            app.Groups.Delete(1, group);
        }
    }
}

