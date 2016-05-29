using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.BankService;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void ButtonAddNewAccount_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
                BankService.AccountDetails accountDetails = new BankService.AccountDetails();
                accountDetails.Name = TextBoxName.Text.Trim();
                accountDetails.Surname = TextBoxSurname.Text.Trim();
                accountDetails.Street = TextBoxStreet.Text.Trim();
                accountDetails.BuildingNumber = TextBoxBuildingNumber.Text.Trim();
                accountDetails.ApartmentNumber = TextBoxApartmentNumber.Text.Trim();
                accountDetails.Postcode = TextBoxPostcode.Text.Trim();
                accountDetails.City = TextBoxCity.Text.Trim();
                string password = TextBoxPassword.Text.Trim();
                string clientNumber = client.addNewAccount(accountDetails, password);

                LabelStatus.Text = "Twój numer klienta: " + clientNumber;

                TextBoxName.Text = String.Empty;
                TextBoxSurname.Text = String.Empty;
                TextBoxStreet.Text = String.Empty;
                TextBoxBuildingNumber.Text = String.Empty;
                TextBoxApartmentNumber.Text = String.Empty;
                TextBoxPostcode.Text = String.Empty;
                TextBoxCity.Text = String.Empty;
                TextBoxPassword.Text = String.Empty;
            }
        }

        protected void ButtonAuthenticateUser_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
                string clientNumber = TextBoxClientNumber.Text.Trim();
                string clientPassword = TextBoxClientPassword.Text.Trim();

                Guid accountNumber = client.authenticateUser(clientNumber, clientPassword);

                if (accountNumber != Guid.Empty)
                {
                    Session["accountNumber"] = accountNumber;
                    TextBoxClientNumber.Text = String.Empty;
                    TextBoxClientPassword.Text = String.Empty;
                    LabelStatus.Text = String.Empty;
                    Response.Redirect("~/AccountManager.aspx", true);
                }
                else
                {
                    TextBoxClientNumber.Text = String.Empty;
                    TextBoxClientPassword.Text = String.Empty;
                    Response.Write("<script>alert('Błędny numer klienta lub hasło');</script>");
                }
            }
        }
    }
}