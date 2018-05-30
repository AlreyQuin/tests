using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class UserCreationTest : AuthBaseClassTest
    {

        public static IEnumerable<DataNewContact> RandomContactDataProvider()
        {
            List<DataNewContact> contact = new List<DataNewContact>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new DataNewContact(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(50),
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(10),
                    MobilePhone = GenerateRandomString(10),
                    WorkPhone = GenerateRandomString(10),
                    Fax = GenerateRandomString(10),
                    Email = GenerateRandomString(15),
                    Email2 = GenerateRandomString(15),
                    Email3 = GenerateRandomString(15),
                    Homepage = GenerateRandomString(20),
                    Address2 = GenerateRandomString(100),
                    Phone2 = GenerateRandomString(10),
                    Notes = GenerateRandomString(40),
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreationContact()
        {

            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            newuser.Middlename = "Edward";
            newuser.Nickname = "IronMan";
            newuser.Company = "Stark Industries";
            newuser.Address = "USA, New-York";

            List<DataNewContact> oldConts = app.Contacts.GetContactList();

            app.Contacts.New(newuser);

            Assert.AreEqual(oldConts.Count + 1, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = app.Contacts.GetContactList();
            oldConts.Add(newuser);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

        }
    }
}
