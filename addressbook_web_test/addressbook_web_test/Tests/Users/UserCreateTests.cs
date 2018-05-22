using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<DataNewUser> oldConts = app.Contacts.GetContactList();

            app.Contacts.New(newuser);

            Assert.AreEqual(oldConts.Count + 1, app.Contacts.GetContactCount());

            List<DataNewUser> newConts = app.Contacts.GetContactList();
            oldConts.Add(newuser);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

        }
    }
}
