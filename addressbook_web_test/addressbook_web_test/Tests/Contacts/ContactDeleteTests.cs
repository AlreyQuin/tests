using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserDeleteTest : ContactTestBase
    {

        [Test]
        public void DeleteContact()
        {
            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            if (!app.Contacts.FindUsers())
            {
                app.Contacts.New(newuser);
            }

            List<DataNewContact> oldConts = DataNewContact.GetAllContact();
            DataNewContact toBeRemoved = oldConts[0];

            app.Contacts.DeleteById(toBeRemoved);

            Assert.AreEqual(oldConts.Count - 1, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = DataNewContact.GetAllContact();
            oldConts.RemoveAt(0);
            Assert.AreEqual(oldConts, newConts);

            foreach (DataNewContact user in newConts)
            {
                Assert.AreNotEqual(user.Id, toBeRemoved.Id);
            }
        }
    }
}
