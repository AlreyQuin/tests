using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupUpdateTests : AuthBaseClassTest
    {

        [Test]
        public void UpdateGroupTest()
        {

            DataGroup newData = new DataGroup("test_2");
            newData.Footer = "Footer";

            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            List<DataGroup> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.FindGroup())
            {
                app.Groups.Create(group);
            }

            app.Groups.Update(0, newData);

            List<DataGroup> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
