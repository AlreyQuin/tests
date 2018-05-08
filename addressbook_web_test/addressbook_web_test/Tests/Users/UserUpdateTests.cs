using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserUpdateTest : BaseClassTest
    {

        [Test]
        public void UpdateUser()
        {


            DataNewUser edit = new DataNewUser("Tony", "Stark");
            edit.Home = "555-7720";
            edit.Mobile = "777-3564";

            app.Contacts.Update(edit, 2);

        }
    }
}
