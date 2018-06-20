using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressbookWebTest
{
    public class GroupTestBase : AuthBaseClassTest
    {

        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<DataGroup> fromUI = app.Groups.GetGroupList();
                List<DataGroup> fromDB = DataGroup.GetAllGroup();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
            
        }
    }
}
