using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupDeleteTest : AuthBaseClassTest
    {
       
        [Test]
        public void DeleteGroupTest()
        {
            DataGroup newGroup = new DataGroup("test");
            newGroup.Header = "test_header";
            newGroup.Footer = "test_footer";

            List<DataGroup> oldGroups = app.Groups.GetGroupList();
            DataGroup toBeRemoved = oldGroups[0];

            if (!app.Groups.FindGroup())
            {
                app.Groups.Create(newGroup);
            }
            app.Groups.Delete(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (DataGroup group in newGroups)
            {
                Assert.AreNotEqual(toBeRemoved.Id, group.Id);
            }
        }
    }
}

