using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class UserCredentials
    {
        private Guid accountNumber;
        private string clientNumber;
        private string saltedPassword;
        private string salt;

        public Guid AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public string ClientNumber
        {
            get { return clientNumber; }
            set { clientNumber = value; }
        }
        public string SaltedPassword
        {
            get { return saltedPassword; }
            set { saltedPassword = value; }
        }
        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        
    }
}
