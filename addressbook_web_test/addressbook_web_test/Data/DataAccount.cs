using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    public class DataAccount
    {

        public DataAccount(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }


        public string Login { get; set; }

        public string Pass { get; set; }
    }
}
