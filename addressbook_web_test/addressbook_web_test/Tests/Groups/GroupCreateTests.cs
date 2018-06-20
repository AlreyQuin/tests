using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace AddressbookWebTest
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<DataGroup> RandomGroupDataProvider()
        {
            List<DataGroup> groups = new List<DataGroup>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new DataGroup(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<DataGroup> GroupDataFromCsvFile()
        {
            List<DataGroup> groups = new List<DataGroup>();
            string[] lines = File.ReadAllLines(@"Groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new DataGroup(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<DataGroup> GroupDataFromXmlFile()
        {
            List<DataGroup> groups = new List<DataGroup>();
            return (List<DataGroup>)
                new XmlSerializer(typeof(List<DataGroup>))
                .Deserialize(new StreamReader(@"Groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreation(DataGroup group)
        {

            List<DataGroup> oldGroups = DataGroup.GetAllGroup();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = DataGroup.GetAllGroup();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void BadNameGroupCreation()
        {
            DataGroup group = new DataGroup("a'a");
            group.Header = "";
            group.Footer = "";

            List<DataGroup> oldGroups = DataGroup.GetAllGroup();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<DataGroup> newGroups = DataGroup.GetAllGroup();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDB()
        {
            DateTime start = DateTime.Now;
            List<DataGroup> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));

            start = DateTime.Now;
            List<DataGroup> fromDb = DataGroup.GetAllGroup();
            end = DateTime.Now;
            System.Console.Out.Write(end.Subtract(start));
        }
    }
}

