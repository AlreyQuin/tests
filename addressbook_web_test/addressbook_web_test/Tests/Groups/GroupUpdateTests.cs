using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupUpdateTests : GroupTestBase
    {

        [Test]
        public void UpdateGroupTest()
        {

            DataGroup newData = new DataGroup("test_2");
            newData.Footer = "Footer";

            DataGroup newGroup = new DataGroup("test");
            newGroup.Header = "test_header";
            newGroup.Footer = "test_footer";

            List<DataGroup> oldGroups = DataGroup.GetAllGroup();
            DataGroup oldData = oldGroups[0];

            if (!app.Groups.FindGroup())
            {
                app.Groups.Create(newGroup);
            }

            app.Groups.UpdateById(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = DataGroup.GetAllGroup();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (DataGroup group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
