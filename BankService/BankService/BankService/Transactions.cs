using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    [DataContract]
    public class Transaction
    {
        private Guid accountNumber;
        private int amount;
        private string operationType;
        private DateTime operationDate;

        [DataMember]
        public Guid AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        [DataMember]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        [DataMember]
        public string OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }
        [DataMember]
        public DateTime OperationDate
        {
            get { return operationDate; }
            set { operationDate = value; }
        }
    }
}
