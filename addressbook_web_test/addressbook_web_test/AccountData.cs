using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookWebTest
{
    public class AccountData
    {
        private string login;
        private string pass;

        public AccountData(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }


        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }
    }
}
