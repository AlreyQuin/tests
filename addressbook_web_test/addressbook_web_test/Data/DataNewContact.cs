using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace AddressbookWebTest
{
    [Table(Name = "addressbook")]
    public class DataNewContact : IEquatable<DataNewContact>, IComparable<DataNewContact>
    {
        private string allPhones;
        private string allEmails;
        private string fullName;
        private string fullData;

        public DataNewContact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public DataNewContact()
        {
        }

        public bool Equals(DataNewContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname = " +  Firstname + ", lastname = " + Lastname + "\nmiddlename  = " + Middlename + "\nnickname = " + Nickname 
                + "\ntitle = " + Title + "\ncompany = " + Company + "\naddress = " + Address + "\nhomePhone = " + HomePhone 
                + "\nmobilePhone = " + MobilePhone + "\nworkPhone = " + WorkPhone + "\nfax = " + Fax + "\nemail = " + Email 
                + "\nemail2 = " + Email2 + "\nemail3 = " + Email3 + "\nhomepage = " + Homepage + "\naddress2 = " + Address2 
                + "\nphone2 = " + Phone2 + "\nnotes = " + Notes;
        }

        public int CompareTo(DataNewContact other)
        {
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<DataNewContact> GetAllContact()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {

                    return (ClearEm(Email) + ClearEm(Email2) + ClearEm(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string ClearEm(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return (ClearName(Firstname) + ClearName(Middlename) + ClearName(Lastname)).Trim();
                }
            }
            set
            {
                fullName = value;
            }
        }

        private string ClearName(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name + " ";
        }

        public string FullData
        {
            get
            {
                if (fullData != null)
                {
                    return fullData;
                }
                else
                {
                    return (ClearData(FullName) + ClearData(Nickname) + ClearData(Title) + ClearData(Company) + ClearData(Address) + "\r\n"
                        + ClearPhone("H: ", HomePhone) + ClearPhone("M: ", MobilePhone) + ClearPhone("W: ", WorkPhone) + ClearPhone("F: ", Fax) + "\r\n"
                        + ClearData(Email) + ClearData(Email2) + ClearData(Email3) + ClearPhone("Homepage:\r\n", Homepage) + "\r\n\r\n"
                        + ClearData(Address2) + "\r\n" + ClearPhone("P: ", Phone2) + "\r\n" + ClearData(Notes)).Trim();
                }
            }
            set
            {
                fullData = value;
            }
        }



            private string ClearData(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
        }

        private string ClearPhone(string simbol, string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return simbol + phone + "\r\n";
        }
    }
}

