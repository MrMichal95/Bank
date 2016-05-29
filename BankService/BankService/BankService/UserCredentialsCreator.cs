using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public static class UserCredentialsCreator
    {
        

        public static UserCredentials createNewUserCredentials(string password)
        {
            UserCredentials credentials = new UserCredentials();
            credentials.AccountNumber = AuthenticationHelper.createNewAccountNumber();
            credentials.ClientNumber = AuthenticationHelper.createNewClientNumber();
            credentials.Salt = AuthenticationHelper.generateSalt();
            credentials.SaltedPassword = AuthenticationHelper.hashPasswordWithSalt(password, credentials.Salt);
            return credentials;
        }

        
        
        
    }
}
