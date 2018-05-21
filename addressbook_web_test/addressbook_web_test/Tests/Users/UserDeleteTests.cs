using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserDeleteTest : AuthBaseClassTest
    {

        [Test]
        public void DeleteUser()
        {
            DataNewUser newuser = new DataNewUser("Tony", "Stark");
            if (!app.Contacts.FindUser())
            {
                app.Contacts.New(newuser);
            }

            List<DataNewUser> oldConts = app.Contacts.GetContactList();

            app.Contacts.Delete(0);

            List<DataNewUser> newConts = app.Contacts.GetContactList();
            oldConts.RemoveAt(0);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);
        }
    }
}
