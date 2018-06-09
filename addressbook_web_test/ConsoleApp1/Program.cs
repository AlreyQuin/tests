using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AddressbookWebTest;

namespace AddressbookTestDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];

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

        }
    }
}
