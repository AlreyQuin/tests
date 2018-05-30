using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressbookWebTest
{
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
            return Firstname + " " + Lastname;
        }

        public int CompareTo(DataNewContact other)
        {
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }
 
        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }

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

