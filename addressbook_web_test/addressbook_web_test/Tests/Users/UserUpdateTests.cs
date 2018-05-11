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

            app.Contacts.Update(edit, 1, newuser);

        }
    }
}
