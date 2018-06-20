using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using AddressbookWebTest;

namespace AddressbookTestDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (type == "group")
            {
                List<DataGroup> groups = new List<DataGroup>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new DataGroup(BaseClassTest.GenerateRandomString(10))
                    {
                        Header = BaseClassTest.GenerateRandomString(10),
                        Footer = BaseClassTest.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXml(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
            else if (type == "contacts")
            {
                List<DataNewContact> contacts = new List<DataNewContact>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new DataNewContact(BaseClassTest.GenerateRandomString(5), 
                        BaseClassTest.GenerateRandomString(10))
                    {
                        Middlename = BaseClassTest.GenerateRandomString(20),
                        Nickname = BaseClassTest.GenerateRandomString(20),
                        Title = BaseClassTest.GenerateRandomString(20),
                        Company = BaseClassTest.GenerateRandomString(10),
                        Address = BaseClassTest.GenerateRandomString(30),
                        HomePhone = BaseClassTest.GenerateRandomString(10),
                        MobilePhone = BaseClassTest.GenerateRandomString(10),
                        WorkPhone = BaseClassTest.GenerateRandomString(10),
                        Fax = BaseClassTest.GenerateRandomString(10),
                        Email = BaseClassTest.GenerateRandomString(15),
                        Email2 = BaseClassTest.GenerateRandomString(15),
                        Email3 = BaseClassTest.GenerateRandomString(15),
                        Homepage = BaseClassTest.GenerateRandomString(20),
                        Address2 = BaseClassTest.GenerateRandomString(30),
                        Phone2 = BaseClassTest.GenerateRandomString(10),
                        Notes = BaseClassTest.GenerateRandomString(10)
                    });
                }
                if (format == "xml")
                {
                    WriteContactsToXml(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
            

        }

        private static void WriteContactsToXml(List<DataNewContact> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<DataNewContact>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToCsvFile(List<DataGroup> groups, StreamWriter writer)
        {
            foreach (DataGroup group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }


        static void WriteGroupsToXml(List<DataGroup> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<DataGroup>)).Serialize(writer, groups);
        }
    }
}
