using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupUpdateTests : BaseClassTest
    {

        [Test]
        public void UpdateGroupTest()
        {

            DataGroup newData = new DataGroup("test_2");
            newData.Footer = "Footer";
            app.Groups.Update(1, newData);
        }
    }
}
