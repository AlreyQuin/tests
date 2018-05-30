using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class ContactInformatoinTest : AuthBaseClassTest
    {

        [Test]
        public void InformContact()
        {
            DataNewContact fromTable = app.Contacts.GetContactInfoFromTable(0);
            DataNewContact fromForm = app.Contacts.GetContactInfoFromForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void InformContactDetail()
        {
            DataNewContact fromTable = app.Contacts.GetContactInfoFromTable(0);
            DataNewContact fromDetails = app.Contacts.GetContactInfoFromDetails(0);

            Assert.AreEqual(fromTable, fromDetails);
            Assert.AreEqual(fromTable.FullData, fromDetails.FullData);
        }
    }
}
