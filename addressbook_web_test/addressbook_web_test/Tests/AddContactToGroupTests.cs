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
        [Test]
        public void TestAddContactToGroup()
        {
            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            DataGroup newGroup = new DataGroup("test");

            if (!app.Contacts.FindUsers())
            {
                app.Contacts.New(newuser);
            }

            if (!app.Groups.FindGroups())
            {
                app.Groups.Create(newGroup);
            }
            List<DataGroup> countGroups = DataGroup.GetAllGroup();
            var contWithoutGroups = new List<DataNewContact>();
            int count = countGroups.Count;
            for (int i = 0; i < count; i++)
            {
                DataGroup gr = DataGroup.GetAllGroup()[i];
                DataNewContact cont = DataNewContact.GetAllContact().Except(gr.GetContactInGroup()).FirstOrDefault();
                if (!contWithoutGroups.Contains(cont))
                {
                    contWithoutGroups.Add(cont);
                }
                
            }

            DataGroup group = DataGroup.GetAllGroup()[0];
            DataNewContact contact = contWithoutGroups[0];
            List<DataNewContact> oldLIst = group.GetContactInGroup();

            app.Contacts.AddContactToGroups(contact, group);

            List<DataNewContact> newList = group.GetContactInGroup();
            oldLIst.Add(contact);
            newList.Sort();
            oldLIst.Sort();
            Assert.AreEqual(oldLIst, newList);
        } 


        [Test]
        public void TestDeleteContactFromGroup()
        {
            DataNewContact newuser = new DataNewContact("Tony", "Stark");
            DataGroup newGroup = new DataGroup("test");
            if (!app.Contacts.FindUsers())
            {
                app.Contacts.New(newuser);
            }

            if (!app.Groups.FindGroups())
            {
                app.Groups.Create(newGroup);
            }

            List<DataGroup> countGroups = DataGroup.GetAllGroup();

            DataGroup group = DataGroup.GetAllGroup()[0];
            List<DataNewContact> oldLIst = group.GetContactInGroup();
            if (oldLIst == null)
            {
                DataNewContact cnt = DataNewContact.GetAllContact().Except(oldLIst).First();
                app.Contacts.AddContactToGroups(cnt, group);
            }
            DataNewContact contact = oldLIst[0];

            app.Contacts.DeleteContactFromGroups(contact, group);

            List<DataNewContact> newList = group.GetContactInGroup();
            oldLIst.Remove(contact);
            newList.Sort();
            oldLIst.Sort();
            Assert.AreEqual(oldLIst, newList);
        }
    }
}
