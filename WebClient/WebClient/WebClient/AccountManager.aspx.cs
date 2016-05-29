using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.BankService;

namespace WebClient
{
    public partial class AccountManager : System.Web.UI.Page
    {
        

        protected void ButtonGetAccountDetails_Click(object sender, EventArgs e)
        {
            UpdateAccountDetails();
        }

        protected void ButtonDepostiMoney_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
                Guid accountNumber = (Guid)Session["accountNumber"];
                Transaction transaction = new Transaction();
                transaction.AccountNumber = accountNumber;
                transaction.Amount = Convert.ToInt32(TextBoxDepostiMoney.Text);
                
                client.depositMoney(transaction);

                UpdateAccountDetails();
                UpdateGridViewTransactions();

                TextBoxDepostiMoney.Text = String.Empty;
            }
        }

        protected void ButtonWithdrawMoney_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
                Guid accountNumber = (Guid)Session["accountNumber"];
                Transaction transaction = new Transaction();
                transaction.AccountNumber = accountNumber;
                transaction.Amount = Convert.ToInt32(TextBoxWithdrawMoney.Text);

                string messageReturned = client.withdrawMoney(transaction);

                if (messageReturned != null)
                {
                    Response.Write("<script>alert('" + messageReturned + "');</script>");
                }
                

                UpdateAccountDetails();
                UpdateGridViewTransactions();

                TextBoxWithdrawMoney.Text = String.Empty;
            }
        }

        protected void ButtonGetAllTransactions_Click(object sender, EventArgs e)
        {
            UpdateGridViewTransactions();
        }

        

        //hide
        protected void GridViewAllTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            //change columns names
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "kwota";
                e.Row.Cells[2].Text = "data wykonania";
                e.Row.Cells[3].Text = "typ transakcji";
            }
            //change of fore color depend on transaction type
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "operationType").Equals("wpłata"))
                {
                    e.Row.ForeColor = System.Drawing.Color.Lime;
                    //e.Row.Cells[1].ForeColor = System.Drawing.Color.Lime;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    //e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        
        private void UpdateAccountDetails()
        {
            Guid accountNumber = (Guid)Session["accountNumber"];
            BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
            AccountDetails accDetails = client.getAccountDetails(accountNumber);

            TextBoxAccountNumber.Text = accDetails.AccountNumber.ToString();
            TextBoxName.Text = accDetails.Name;
            TextBoxSurname.Text = accDetails.Surname;
            TextBoxStreet.Text = accDetails.Street;
            TextBoxBuildingNumber.Text = accDetails.BuildingNumber;
            TextBoxApartmentNumber.Text = accDetails.ApartmentNumber;
            TextBoxPostcode.Text = accDetails.Postcode;
            TextBoxCity.Text = accDetails.City;
            TextBoxAccountBalance.Text = Convert.ToString(accDetails.AccountBalance);
            TextBoxCreationDate.Text = Convert.ToString(accDetails.CreationDate);
        }

        private void UpdateGridViewTransactions()
        {
            BankService.BankServiceClient client = new BankService.BankServiceClient("NetTcpBinding_IBankService");
            Guid accountNumber = (Guid)Session["accountNumber"];
            List<Transaction> allTransactions = client.getAllTransactions(accountNumber).ToList<Transaction>();

            GridViewAllTransactions.DataSource = allTransactions;
            GridViewAllTransactions.DataBind();
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session["accountNumber"] = Guid.Empty;
            Response.Redirect("~/RegisterLoginForm.aspx", true);
        }
    }
}