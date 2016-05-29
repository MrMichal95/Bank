<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountManager.aspx.cs" Inherits="WebClient.AccountManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center;margin-bottom:50px">
            <h1>Bank</h1>
            <p>Tutaj mozesz zobaczyć dane konta, wpłacić, wypłacić z konta oraz przejrzeć listę transakcji</p>
            </div>

        <div style="text-align:center; width:60%;vertical-align:middle;margin:auto;height:60px">
            <div style="float:left">
            <asp:Button ID="ButtonLogout" runat="server" Text="Wyloguj" OnClick="ButtonLogout_Click" />
                </div>
        </div>

        <div style="width:70%;vertical-align: middle;margin:auto;margin-bottom:400px;">
        <!-- get account detalis -->
        <div style="width: 50%;  vertical-align: middle;float:left">
        <table style="margin:auto">
            <tr>
                <td>
                    <h3>
                        Dane konta
                    </h3>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonGetAccountDetails" runat="server" Text="Pobierz informacje o koncie" OnClick="ButtonGetAccountDetails_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Numer konta
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAccountNumber" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Imie
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Nazwisko
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSurname" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Ulica
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStreet" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Numer budynku
                </td>
                <td>
                    <asp:TextBox ID="TextBoxBuildingNumber" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Numer mieszkania
                </td>
                <td>
                    <asp:TextBox ID="TextBoxApartmentNumber" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Kod pocztowy
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostcode" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Miasto
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCity" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Stan konta
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAccountBalance" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Data utworzenia
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCreationDate" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
            </div>
            
        <!-- gridview transactions -->
        <div style="width: 30%;  vertical-align: middle;float:right;height:340px;overflow:auto">
        <table >
            <tr>
                <td>
                    <h3>
                        Lista transakcji
                    </h3>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonGetAllTransactions" runat="server" Text="Pobierz listę transakcji" OnClick="ButtonGetAllTransactions_Click" />
                </td>
            </tr>
            <tr>
                <asp:GridView ID="GridViewAllTransactions" runat="server" OnRowDataBound="GridViewAllTransactions_RowDataBound">
                </asp:GridView>
            </tr>
        </table>
            </div>
            </div>
        
        <div style="width:90%;vertical-align: middle;margin:auto;">
        <!-- deposit money -->
        <div style="width: 50%;  vertical-align: middle;float:right">
        <table style="margin:auto">
            <tr>
                <td>
                    <h3>
                        Wpłać pienądze
                    </h3>
                </td>
            </tr>
            <tr>
                <td>
                    Ile
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDepostiMoney" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepositMoney" runat="server" ErrorMessage="Podaj kwotę (dodatnia liczba)" ControlToValidate="TextBoxDepostiMoney" Display="Dynamic" ForeColor="Red" ValidationGroup="deposit">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidatorDepositMoney" runat="server" ErrorMessage="Kwota musi być większa od 0" ControlToValidate="TextBoxDepostiMoney" MinimumValue="1" MaximumValue="2000000000" Display="Dynamic" ForeColor="Red" ValidationGroup="deposit" Type="Integer">*</asp:RangeValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDepositMoney" runat="server" ErrorMessage="Pole tekstowe wpłać pieniądze może zawierać tylko cyfry" ControlToValidate="TextBoxDepostiMoney" ValidationExpression="^[0-9]+$" Display="Dynamic" ForeColor="Red" ValidationGroup="deposit">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="deposit" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonDepostiMoney" runat="server" Text="Wpłać" OnClick="ButtonDepostiMoney_Click" ValidationGroup="deposit" />
                </td>
            </tr>
        </table>
            </div>
        <!-- withdraw money -->
        <div style="width: 50%;  vertical-align: middle;float:left">
        <table style="margin:auto">
            <tr>
                <td>
                    <h3>
                        Wypłać pieniądze
                    </h3>
                </td>
            </tr>
            <tr>
                <td>
                    Ile
                </td>
                <td>
                    <asp:TextBox ID="TextBoxWithdrawMoney" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWithdrawMoney" runat="server" ErrorMessage="Podaj kwotę (dodatnia liczba)" ControlToValidate="TextBoxWithdrawMoney" Display="Dynamic" ForeColor="Red" ValidationGroup="withdraw">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1WithdrawMoney" runat="server" ErrorMessage="Kwota musi być większa od 0" ControlToValidate="TextBoxWithdrawMoney" MinimumValue="1" MaximumValue="2000000000" Display="Dynamic" ForeColor="Red" ValidationGroup="withdraw" Type="Integer">*</asp:RangeValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1WithdrawMoney" runat="server" ErrorMessage="Pole tekstowe wpłać pieniądze może zawierać tylko cyfry" ControlToValidate="TextBoxWithdrawMoney" ValidationExpression="^[0-9]+$" Display="Dynamic" ForeColor="Red" ValidationGroup="withdraw">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="withdraw" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonWithdrawMoney" runat="server" Text="Wypłać" OnClick="ButtonWithdrawMoney_Click" ValidationGroup="withdraw" />
                </td>
            </tr>
        </table>
        </div>
            </div>
            </div>
    </div>
    </form>
</body>
</html>
