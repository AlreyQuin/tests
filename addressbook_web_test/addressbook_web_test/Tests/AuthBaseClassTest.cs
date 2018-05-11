using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AddressbookWebTest
{
    public class AuthBaseClassTest : BaseClassTest
    {

        [SetUp]
        public void SetupLogin()
        {
            app.Logon.Login(new DataAccount("admin", "secret"));
        }
    }
}
