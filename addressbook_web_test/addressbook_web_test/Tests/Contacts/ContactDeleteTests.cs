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
        public void DeleteContact()
        {
            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            if (!app.Contacts.FindUser())
            {
                app.Contacts.New(newuser);
            }

            List<DataNewContact> oldConts = app.Contacts.GetContactList();
            DataNewContact toBeRemoved = oldConts[0];

            app.Contacts.Delete(0);

            Assert.AreEqual(oldConts.Count - 1, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = app.Contacts.GetContactList();
            oldConts.RemoveAt(0);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

            foreach (DataNewContact user in newConts)
            {
                Assert.AreNotEqual(toBeRemoved.Id, user.Id);
            }
        }
    }
}
