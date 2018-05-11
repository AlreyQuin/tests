using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserCreationTest : AuthBaseClassTest
    {

        [Test]
        public void CreationUser()
        {
            

            DataNewUser newuser = new DataNewUser("Tony", "Stark");
            newuser.Middlename = "Edward";
            newuser.Nickname = "IronMan";
            newuser.Company = "Stark Industries";
            newuser.Address = "USA, New-York";

            app.Contacts.New(newuser);

        }
    }
}
