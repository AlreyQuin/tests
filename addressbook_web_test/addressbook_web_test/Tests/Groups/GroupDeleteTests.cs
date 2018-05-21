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
            DataGroup group = new DataGroup("test");
            group.Header = "test_header";
            group.Footer = "test_footer";

            List<DataGroup> oldGroups = app.Groups.GetGroupList();

            if (!app.Groups.FindGroup())
            {
                app.Groups.Create(group);
            }
            app.Groups.Delete(0);

            List<DataGroup> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

