using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BankService
{
    [DataContract]
    public class AccountDetails
    {
        private Guid accountNumber;
        private string name;
        private string surname;
        private string street;
        private string buildingNumber;
        private string apartmentNumber;
        private string postcode;
        private string city;
        private int accountBalance;
        private DateTime creationDate;

        [DataMember]
        public Guid AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [DataMember]
        public string BuildingNumber
        {
            get { return buildingNumber; }
            set { buildingNumber = value; }
        }
        [DataMember]
        public string ApartmentNumber
        {
            get { return apartmentNumber; }
            set { apartmentNumber = value; }
        }
        [DataMember]
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [DataMember]
        public int AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }
        [DataMember]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
    }
}
