using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace AddressbookWebTest
{
    [Table(Name = "group_list" )]
    public class DataGroup : IEquatable<DataGroup>, IComparable<DataGroup>
    {

        public DataGroup(string name)
        {
            Name = name;
        }

        public DataGroup()
        {
        }

        public bool Equals(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(DataGroup other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<DataGroup> GetAllGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
       
    }
}
