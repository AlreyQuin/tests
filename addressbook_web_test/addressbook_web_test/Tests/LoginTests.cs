using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressbookWebTest
{
    [TestFixture]
    public class LoginTests : BaseClassTest
    {
        [Test]
        public void LoginWithValidData()
        {
            app.Logon.Logout();

            DataAccount validData = new DataAccount("admin", "secret");
            app.Logon.Login(validData);
            Assert.IsTrue(app.Logon.IsLoggedIn(validData));
        }

        [Test]
        public void LoginWithNotValidData()
        {
            app.Logon.Logout();

            DataAccount notValidData = new DataAccount("admin", "123");
            app.Logon.Login(notValidData);
            Assert.IsFalse(app.Logon.IsLoggedIn());
        }
    }
}
