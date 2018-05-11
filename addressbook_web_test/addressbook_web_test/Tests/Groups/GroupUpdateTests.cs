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

            app.Groups.Update(1, newData, group);
        }
    }
}
