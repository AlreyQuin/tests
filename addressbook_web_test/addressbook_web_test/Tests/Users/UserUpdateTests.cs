using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserUpdateTest : AuthBaseClassTest
    {

        [Test]
        public void UpdateUser()
        {

            DataNewUser newuser = new DataNewUser("Tony", "Stark");
            DataNewUser edit = new DataNewUser("Virginia", "Potts");
            edit.Home = "555-7720";
            edit.Mobile = "777-3564";

            List<DataNewUser> oldConts = app.Contacts.GetContactList();

            if (!app.Contacts.FindUser())
            {
                app.Contacts.New(newuser);
            }
            app.Contacts.Update(edit, 0);

            List<DataNewUser> newConts = app.Contacts.GetContactList();
            oldConts[0].Firstname = edit.Firstname;
            oldConts[0].Lastname = edit.Lastname;
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

        }
    }
}
