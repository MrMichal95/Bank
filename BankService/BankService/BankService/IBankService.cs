using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBankService" in both code and config file together.
    [ServiceContract]
    public interface IBankService
    {
        
        [OperationContract]
        string addNewAccount(AccountDetails accDetails, string password);

        [OperationContract]
        AccountDetails getAccountDetails(Guid accountNumber);

        [OperationContract]
        void depositMoney(Transaction transaction);

        [OperationContract]
        string withdrawMoney(Transaction transaction);

        [OperationContract]
        List<Transaction> getAllTransactions(Guid accountNumber);

        [OperationContract]
        Guid authenticateUser(string clientNumber,string password);
        
    }
}
