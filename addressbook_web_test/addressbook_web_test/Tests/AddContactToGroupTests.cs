using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    public class AddContactToGroupTests : AuthBaseClassTest
    {
        /*[Test]
        public void TestAddContactToGroup()
        {
            List<DataGroup> countGroups = DataGroup.GetAllGroup();
            var contWithoutGroups = new List<DataNewContact>();
            int count = countGroups.Count;
            for (int i = 0; i < count; i++)
            {
                DataGroup group = DataGroup.GetAllGroup()[i];
                DataNewContact cont = DataNewContact.GetAllContact().Except(group.GetContactInGroup()).First();
                contWithoutGroups.Add(cont)
            }

        } */

        [Test]
        public void TestAddContactToGroup()
        {
            DataGroup group = DataGroup.GetAllGroup()[0];
            List<DataNewContact> oldLIst = group.GetContactInGroup();
            DataNewContact cont = DataNewContact.GetAllContact().Except(oldLIst).First();

            app.Contacts.AddContactToGroups(cont, group);

            List<DataNewContact> newList = group.GetContactInGroup();
            oldLIst.Add(cont);
            newList.Sort();
            oldLIst.Sort();
            Assert.AreEqual(oldLIst, newList);
        }

        [Test]
        public void TestDeleteContactFromGroup()
        {
            DataGroup group = DataGroup.GetAllGroup()[0];
            List<DataNewContact> oldLIst = group.GetContactInGroup();
            DataNewContact cont = oldLIst[0];

            app.Contacts.DeleteContactFromGroups(cont, group);

            List<DataNewContact> newList = group.GetContactInGroup();
            oldLIst.Remove(cont);
            newList.Sort();
            oldLIst.Sort();
            Assert.AreEqual(oldLIst, newList);
        }
    }
}
