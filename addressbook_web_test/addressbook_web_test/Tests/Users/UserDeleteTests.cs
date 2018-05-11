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
            app.Contacts.Delete(1, newuser);
        }
    }
}
