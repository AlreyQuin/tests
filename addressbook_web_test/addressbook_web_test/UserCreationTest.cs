using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserCreationTest : BaseClassTest
    {

        [Test]
        public void CreationUser()
        {
            helperNavigation.OpenPage();
            helperLogin.Login(new DataAccount("admin", "secret"));
            helperNavigation.GoToHomePage();
            helperContact.CreateNewUser();

            DataNewUser newuser = new DataNewUser("Tony", "Stark");
            newuser.Middlename = "Edward";
            newuser.Nickname = "IronMan";
            newuser.Company = "Stark Industries";
            newuser.Address = "USA, New-York";
            newuser.Bday = "10";
            newuser.Bmonth = "March";
            newuser.Byear = "1963";

            helperContact.FillUserForm(newuser);
            helperNavigation.GoToHomePage();
        }
    }
}
