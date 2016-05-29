using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BankService" in both code and config file together.
    public class BankService : IBankService
    {
        #region interface implementation
        public string addNewAccount(AccountDetails accDetails,string password)
        {
            UserCredentials credentials = UserCredentialsCreator.createNewUserCredentials(password);
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAddNewAccount", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@accountNumber", credentials.AccountNumber);
                command.Parameters.AddWithValue("@name", accDetails.Name);
                command.Parameters.AddWithValue("@surname", accDetails.Surname);
                command.Parameters.AddWithValue("@street", accDetails.Street);
                command.Parameters.AddWithValue("@buildingNumber", accDetails.BuildingNumber);
                command.Parameters.AddWithValue("@apartmentNumber", accDetails.ApartmentNumber);
                command.Parameters.AddWithValue("@postcode", accDetails.Postcode);
                command.Parameters.AddWithValue("@city", accDetails.City);
                command.Parameters.AddWithValue("@accountBalance", accDetails.AccountBalance);
                command.Parameters.AddWithValue("@clientNumber", credentials.ClientNumber);
                command.Parameters.AddWithValue("@saltedPassword", credentials.SaltedPassword);
                command.Parameters.AddWithValue("@salt", credentials.Salt);
                command.Parameters.AddWithValue("@creationDate", DateTime.Now.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                
            }
            return credentials.ClientNumber;
        }

        public AccountDetails getAccountDetails(Guid accountNumber)
        {
            AccountDetails accDetails = new AccountDetails();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReturnAccountDetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@accountNumber", accountNumber);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    accDetails.AccountNumber = new Guid(Convert.ToString(dataReader["accountNumber"]));
                    accDetails.Name = Convert.ToString(dataReader["name"]);
                    accDetails.Surname = Convert.ToString(dataReader["surname"]);
                    accDetails.Street = Convert.ToString(dataReader["street"]);
                    accDetails.BuildingNumber = Convert.ToString(dataReader["buildingNumber"]);
                    accDetails.ApartmentNumber = Convert.ToString(dataReader["apartmentNumber"]);
                    accDetails.Postcode = Convert.ToString(dataReader["postcode"]);
                    accDetails.City = Convert.ToString(dataReader["city"]);
                    accDetails.AccountBalance = Convert.ToInt32(dataReader["accountBalance"]);
                    accDetails.CreationDate = Convert.ToDateTime(dataReader["creationDate"]);
                }
            }

            return accDetails;
        }

        public void depositMoney(Transaction transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDepositMoney", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@accountNumber", transaction.AccountNumber);
                command.Parameters.AddWithValue("@amount", transaction.Amount);
                command.Parameters.AddWithValue("@operationType", "wpłata");
                command.Parameters.AddWithValue("@operationDate", DateTime.Now.ToString());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public string withdrawMoney(Transaction transaction)
        {
            if (isTransactionPossible(transaction.AccountNumber, transaction.Amount))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spWithdrawMoney", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@accountNumber", transaction.AccountNumber);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@operationType", "wypłata");
                    command.Parameters.AddWithValue("@operationDate", DateTime.Now.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return null;
            }
            else
            {
                return "Nie można wypłacić żądanej kwoty zbyt mało pieniędzy na koncie";
            }
        }

        public List<Transaction> getAllTransactions(Guid accountNumber)
        {
            List<Transaction> transactionsList = new List<Transaction>();
            SqlDataReader dataReader = null;
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReturnAllTransactions", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@accountNumber", accountNumber.ToString());

                connection.Open();
                dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    Transaction newTransaction = new Transaction();
                    newTransaction.Amount = Convert.ToInt32(dataReader["amount"]);
                    newTransaction.OperationType = Convert.ToString(dataReader["operationType"]);
                    newTransaction.OperationDate = Convert.ToDateTime(dataReader["operationDate"]);
                    transactionsList.Add(newTransaction);
                }
            }

            return transactionsList;
            
        }

       
        public Guid authenticateUser(string clientNumber, string password)
        {
            SqlDataReader dataReader = null;
            UserCredentials credentialsRetrievedFromDB = new UserCredentials();
            UserCredentials credentialsToCompare = new UserCredentials();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //if client number exist in database
            

            //retrieving salt,accountNumber and salted password from db
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReturnSaltAndSaltedPassword", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@clientNumber", clientNumber);

                connection.Open();
                dataReader = command.ExecuteReader();

                //if client number is invalid
                if (!dataReader.HasRows) return Guid.Empty;

                //adding values to credentials form db
                while (dataReader.Read())
                {
                    credentialsRetrievedFromDB.Salt = Convert.ToString(dataReader["salt"]);
                    credentialsRetrievedFromDB.SaltedPassword = Convert.ToString(dataReader["saltedPassword"]);
                    credentialsRetrievedFromDB.AccountNumber = new Guid(Convert.ToString(dataReader["accountNumber"]));
                }
            }

            //salting password
            credentialsToCompare.SaltedPassword = AuthenticationHelper.hashPasswordWithSalt(password, credentialsRetrievedFromDB.Salt);

            //comparing salted passwords and returning acc number if match or guid Empty
            return (credentialsRetrievedFromDB.SaltedPassword.Equals(credentialsToCompare.SaltedPassword)
                ? credentialsRetrievedFromDB.AccountNumber
                : Guid.Empty);

        }
        #endregion

        private bool isTransactionPossible(Guid accountNumber, int amount)
        {
            int accountBalance = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spReturnAccountBalance", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@accountNumber", accountNumber);

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    accountBalance = Convert.ToInt32(dataReader["accountBalance"]);
                }
            }
            return (accountBalance - amount >= 0) ? true : false;
        }
        
    }
}
