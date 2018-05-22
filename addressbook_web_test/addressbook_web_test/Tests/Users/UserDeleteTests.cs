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
            DataNewUser toBeRemoved = oldConts[0];

            app.Contacts.Delete(0);

            Assert.AreEqual(oldConts.Count - 1, app.Contacts.GetContactCount());

            List<DataNewUser> newConts = app.Contacts.GetContactList();
            oldConts.RemoveAt(0);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

            foreach (DataNewUser user in newConts)
            {
                Assert.AreNotEqual(toBeRemoved.Id, user.Id);
            }
        }
    }
}
