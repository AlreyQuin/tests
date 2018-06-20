using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    public class ContactTestBase : AuthBaseClassTest
    {

    [TearDown]
    public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<DataNewContact> fromUI = app.Contacts.GetContactList();
                List<DataNewContact> fromDB = DataNewContact.GetAllContact();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
    
