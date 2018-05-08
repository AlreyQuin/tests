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
            app.Navigation.OpenPage();
            app.Logon.Login(new DataAccount("admin", "secret"));
            app.Navigation.GoToHomePage();
            app.Contacts.CreateNewUser();

            DataNewUser newuser = new DataNewUser("Tony", "Stark");
            newuser.Middlename = "Edward";
            newuser.Nickname = "IronMan";
            newuser.Company = "Stark Industries";
            newuser.Address = "USA, New-York";
            newuser.Bday = "10";
            newuser.Bmonth = "March";
            newuser.Byear = "1963";

            app.Contacts.FillUserForm(newuser);
            app.Navigation.GoToHomePage();
        }
    }
}
