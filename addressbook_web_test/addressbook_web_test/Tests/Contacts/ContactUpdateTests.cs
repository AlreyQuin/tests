using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class ContactUpdateTest : AuthBaseClassTest
    {

        [Test]
        public void UpdateContact()
        {

            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            DataNewContact edit = new DataNewContact("Virginia", "Potts");
            edit.HomePhone = "555-7720";
            edit.MobilePhone = "777-3564";

            List<DataNewContact> oldConts = app.Contacts.GetContactList();
            DataNewContact oldUser = oldConts[0];

            if (!app.Contacts.FindUser())
            {
                app.Contacts.New(newuser);
            }
            app.Contacts.Update(edit, 0);

            Assert.AreEqual(oldConts.Count, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = app.Contacts.GetContactList();
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
