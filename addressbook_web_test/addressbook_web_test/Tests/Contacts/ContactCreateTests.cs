﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTest 
{
    [TestFixture]
    public class UserCreationTest : ContactTestBase
    {

        public static IEnumerable<DataNewContact> RandomContactDataProvider()
        {
            List<DataNewContact> contact = new List<DataNewContact>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new DataNewContact(GenerateRandomString(10), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    HomePhone = GenerateRandomString(10),
                    MobilePhone = GenerateRandomString(10),
                    WorkPhone = GenerateRandomString(10),
                    Fax = GenerateRandomString(10),
                    Email = GenerateRandomString(15),
                    Email2 = GenerateRandomString(15),
                    Email3 = GenerateRandomString(15),
                    Homepage = GenerateRandomString(20),
                    Address2 = GenerateRandomString(30),
                    Phone2 = GenerateRandomString(10),
                    Notes = GenerateRandomString(30),
                });
            }
            return contact;
        }

        public static IEnumerable<DataNewContact> ContactDataFromXmlFile()
        {
            List<DataNewContact> contacts = new List<DataNewContact>();
            return (List<DataNewContact>)
                new XmlSerializer(typeof(List<DataNewContact>))
                .Deserialize(new StreamReader(@"Contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void CreationContact(DataNewContact newuser)
        {

            List<DataNewContact> oldConts = DataNewContact.GetAllContact();

            app.Contacts.New(newuser);

            Assert.AreEqual(oldConts.Count + 1, app.Contacts.GetContactCount());

            List<DataNewContact> newConts = DataNewContact.GetAllContact();
            oldConts.Add(newuser);
            oldConts.Sort();
            newConts.Sort();
            Assert.AreEqual(oldConts, newConts);

        }
    }
}
