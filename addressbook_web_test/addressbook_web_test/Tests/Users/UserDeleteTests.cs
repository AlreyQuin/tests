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
            app.Contacts.Delete(1);
        }
    }
}
