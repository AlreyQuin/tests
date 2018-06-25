using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class ContactUpdateTest : ContactTestBase
    {

        [Test]
        public void UpdateContact()
        {

            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            DataNewContact edit = new DataNewContact("Virginia", "Potts");
            edit.HomePhone = "555-7720";
            edit.MobilePhone = "777-3564";

            if (!app.Contacts.FindUsers())
            {
                app.Contacts.New(newuser);
            }

            List<DataNewContact> oldConts = DataNewContact.GetAllContact();
            DataNewContact oldUser = oldConts[0];

            app.Contacts.Update(edit, 0);

            Assert.AreEqual(oldConts.Count, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = DataNewContact.GetAllContact();
            oldConts[0].Firstname = edit.Firstname;
            oldConts[0].Lastname = edit.Lastname;
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

            foreach (DataNewContact user in newConts)
            {
                if (user.Id == oldUser.Id)
                {
                    Assert.AreEqual(edit.Firstname, user.Firstname);
                }
            }

        }
    }
}
