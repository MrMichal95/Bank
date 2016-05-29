using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public static class AuthenticationHelper
    {
        
        public static Guid createNewAccountNumber()
        {
            return Guid.NewGuid();
        }

        public static string createNewClientNumber()
        {
            string result = string.Empty;
            do
            {
                do
                {
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    byte[] data = new byte[4];
                    rng.GetBytes(data);
                    int value = BitConverter.ToInt32(data, 0);
                    value = Math.Abs(value);
                    result = Convert.ToString(value);
                } while (result.Length != 9);
            } while (!isClientNumberUnique(result));

            return result;
        }
        public static string generateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var bytes = new Byte[32];
            rng.GetBytes(bytes);
            return BitConverter.ToString(bytes);

        }
        public static string hashPasswordWithSalt(string password, string salt)
        {
            string tempPass = salt + password;
            var sha256 = SHA256.Create();

            Byte[] inputBytes = Encoding.UTF8.GetBytes(tempPass);

            Byte[] hashedBytes = sha256.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);

        }

        public static bool isClientNumberUnique(string clientNumberToCompare)
        {
            List<string> clientNumbersList = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReturnAllClientNumbers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string clientNumberFromDB = Convert.ToString(dataReader["clientNumber"]);
                    clientNumbersList.Add(clientNumberFromDB);
                }
            }

            foreach(string clientNumberFromList in clientNumbersList)
            {
                if (clientNumberFromList.Equals(clientNumberToCompare)) return false;
            }

            return true;
        }
    }
}
