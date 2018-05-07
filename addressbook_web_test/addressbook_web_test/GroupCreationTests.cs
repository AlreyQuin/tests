using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupCreationTests : BaseClassTest
    {

        [Test]
        public void GroupCreation()
        {
            OpenPage();
            Login(new DataAccount("admin", "secret"));
            OpenGroupPage();
            InitCreateGroup();

            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            FillGroupForm(group);
            OpenGroupPage();
        }
    }
}

