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
            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreation()
        {
            DataGroup group = new DataGroup("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}

