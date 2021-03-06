﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.BankService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccountDetails", Namespace="http://schemas.datacontract.org/2004/07/BankService")]
    [System.SerializableAttribute()]
    public partial class AccountDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AccountBalanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid AccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApartmentNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostcodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StreetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AccountBalance {
            get {
                return this.AccountBalanceField;
            }
            set {
                if ((this.AccountBalanceField.Equals(value) != true)) {
                    this.AccountBalanceField = value;
                    this.RaisePropertyChanged("AccountBalance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid AccountNumber {
            get {
                return this.AccountNumberField;
            }
            set {
                if ((this.AccountNumberField.Equals(value) != true)) {
                    this.AccountNumberField = value;
                    this.RaisePropertyChanged("AccountNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApartmentNumber {
            get {
                return this.ApartmentNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ApartmentNumberField, value) != true)) {
                    this.ApartmentNumberField = value;
                    this.RaisePropertyChanged("ApartmentNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuildingNumber {
            get {
                return this.BuildingNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingNumberField, value) != true)) {
                    this.BuildingNumberField = value;
                    this.RaisePropertyChanged("BuildingNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationDate {
            get {
                return this.CreationDateField;
            }
            set {
                if ((this.CreationDateField.Equals(value) != true)) {
                    this.CreationDateField = value;
                    this.RaisePropertyChanged("CreationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Postcode {
            get {
                return this.PostcodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostcodeField, value) != true)) {
                    this.PostcodeField = value;
                    this.RaisePropertyChanged("Postcode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Street {
            get {
                return this.StreetField;
            }
            set {
                if ((object.ReferenceEquals(this.StreetField, value) != true)) {
                    this.StreetField = value;
                    this.RaisePropertyChanged("Street");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Transaction", Namespace="http://schemas.datacontract.org/2004/07/BankService")]
    [System.SerializableAttribute()]
    public partial class Transaction : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid AccountNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OperationDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OperationTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid AccountNumber {
            get {
                return this.AccountNumberField;
            }
            set {
                if ((this.AccountNumberField.Equals(value) != true)) {
                    this.AccountNumberField = value;
                    this.RaisePropertyChanged("AccountNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OperationDate {
            get {
                return this.OperationDateField;
            }
            set {
                if ((this.OperationDateField.Equals(value) != true)) {
                    this.OperationDateField = value;
                    this.RaisePropertyChanged("OperationDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationType {
            get {
                return this.OperationTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.OperationTypeField, value) != true)) {
                    this.OperationTypeField = value;
                    this.RaisePropertyChanged("OperationType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankService.IBankService")]
    public interface IBankService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/addNewAccount", ReplyAction="http://tempuri.org/IBankService/addNewAccountResponse")]
        string addNewAccount(WebClient.BankService.AccountDetails accDetails, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/addNewAccount", ReplyAction="http://tempuri.org/IBankService/addNewAccountResponse")]
        System.Threading.Tasks.Task<string> addNewAccountAsync(WebClient.BankService.AccountDetails accDetails, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/getAccountDetails", ReplyAction="http://tempuri.org/IBankService/getAccountDetailsResponse")]
        WebClient.BankService.AccountDetails getAccountDetails(System.Guid accountNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/getAccountDetails", ReplyAction="http://tempuri.org/IBankService/getAccountDetailsResponse")]
        System.Threading.Tasks.Task<WebClient.BankService.AccountDetails> getAccountDetailsAsync(System.Guid accountNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/depositMoney", ReplyAction="http://tempuri.org/IBankService/depositMoneyResponse")]
        void depositMoney(WebClient.BankService.Transaction transaction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/depositMoney", ReplyAction="http://tempuri.org/IBankService/depositMoneyResponse")]
        System.Threading.Tasks.Task depositMoneyAsync(WebClient.BankService.Transaction transaction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/withdrawMoney", ReplyAction="http://tempuri.org/IBankService/withdrawMoneyResponse")]
        string withdrawMoney(WebClient.BankService.Transaction transaction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/withdrawMoney", ReplyAction="http://tempuri.org/IBankService/withdrawMoneyResponse")]
        System.Threading.Tasks.Task<string> withdrawMoneyAsync(WebClient.BankService.Transaction transaction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/getAllTransactions", ReplyAction="http://tempuri.org/IBankService/getAllTransactionsResponse")]
        WebClient.BankService.Transaction[] getAllTransactions(System.Guid accountNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/getAllTransactions", ReplyAction="http://tempuri.org/IBankService/getAllTransactionsResponse")]
        System.Threading.Tasks.Task<WebClient.BankService.Transaction[]> getAllTransactionsAsync(System.Guid accountNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/authenticateUser", ReplyAction="http://tempuri.org/IBankService/authenticateUserResponse")]
        System.Guid authenticateUser(string clientNumber, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankService/authenticateUser", ReplyAction="http://tempuri.org/IBankService/authenticateUserResponse")]
        System.Threading.Tasks.Task<System.Guid> authenticateUserAsync(string clientNumber, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankServiceChannel : WebClient.BankService.IBankService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankServiceClient : System.ServiceModel.ClientBase<WebClient.BankService.IBankService>, WebClient.BankService.IBankService {
        
        public BankServiceClient() {
        }
        
        public BankServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string addNewAccount(WebClient.BankService.AccountDetails accDetails, string password) {
            return base.Channel.addNewAccount(accDetails, password);
        }
        
        public System.Threading.Tasks.Task<string> addNewAccountAsync(WebClient.BankService.AccountDetails accDetails, string password) {
            return base.Channel.addNewAccountAsync(accDetails, password);
        }
        
        public WebClient.BankService.AccountDetails getAccountDetails(System.Guid accountNumber) {
            return base.Channel.getAccountDetails(accountNumber);
        }
        
        public System.Threading.Tasks.Task<WebClient.BankService.AccountDetails> getAccountDetailsAsync(System.Guid accountNumber) {
            return base.Channel.getAccountDetailsAsync(accountNumber);
        }
        
        public void depositMoney(WebClient.BankService.Transaction transaction) {
            base.Channel.depositMoney(transaction);
        }
        
        public System.Threading.Tasks.Task depositMoneyAsync(WebClient.BankService.Transaction transaction) {
            return base.Channel.depositMoneyAsync(transaction);
        }
        
        public string withdrawMoney(WebClient.BankService.Transaction transaction) {
            return base.Channel.withdrawMoney(transaction);
        }
        
        public System.Threading.Tasks.Task<string> withdrawMoneyAsync(WebClient.BankService.Transaction transaction) {
            return base.Channel.withdrawMoneyAsync(transaction);
        }
        
        public WebClient.BankService.Transaction[] getAllTransactions(System.Guid accountNumber) {
            return base.Channel.getAllTransactions(accountNumber);
        }
        
        public System.Threading.Tasks.Task<WebClient.BankService.Transaction[]> getAllTransactionsAsync(System.Guid accountNumber) {
            return base.Channel.getAllTransactionsAsync(accountNumber);
        }
        
        public System.Guid authenticateUser(string clientNumber, string password) {
            return base.Channel.authenticateUser(clientNumber, password);
        }
        
        public System.Threading.Tasks.Task<System.Guid> authenticateUserAsync(string clientNumber, string password) {
            return base.Channel.authenticateUserAsync(clientNumber, password);
        }
    }
}
