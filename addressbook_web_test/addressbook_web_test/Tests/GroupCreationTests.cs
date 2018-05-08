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
            app.Navigation.OpenPage();
            app.Logon.Login(new DataAccount("admin", "secret"));
            app.Navigation.OpenGroupPage();
            app.Groups.InitCreateGroup();

            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            app.Groups.FillGroupForm(group);
            app.Groups.SubmitCreateGroup();
            app.Navigation.OpenGroupPage();
        }
    }
}

