<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterLoginForm.aspx.cs" Inherits="WebClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center;margin-bottom:100px">
            <h1>Bank</h1>
            <p>Zaloguj się lub zarejestruj. Po założeniu konta zostanie wyświetlony numer klienta, użyj go aby sie zalogować do banku</p>
            </div>
        <div style="width:50%;vertical-align: middle;margin:auto;">
        <div style="width: 50%;  vertical-align: middle;float:left">
            <table style="margin:auto">
                <tr>
                    <td>
                        <h3>Zarejestruj się</h3>
                    </td>
                </tr>
            <tr>
                <td>
                    Imię
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Pole tekstowe imie nie może być puste" ControlToValidate="TextBoxName" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ErrorMessage="Imie może zawierać tylko litery od A-Z" ValidationExpression="^[a-zA-Z\s-żźćńółęąśŻŹĆĄŚĘŁÓŃ.]+$" ControlToValidate="TextBoxName" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>
                </td>
                
            </tr>
            <tr>
                <td>
                    Nazwisko
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurname" runat="server" ErrorMessage="Pole tekstowe nazwisko nie może być puste" ControlToValidate="TextBoxSurname" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorSurname" runat="server" ErrorMessage="Nazwisko może zawierać tylko litery od A-Z" ValidationExpression="^[a-zA-Z\s-żźćńółęąśŻŹĆĄŚĘŁÓŃ.]+$" ControlToValidate="TextBoxSurname" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Ulica
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStreet" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorStreet" runat="server" ErrorMessage="Pole tekstowe ulica nie może być puste" ControlToValidate="TextBoxStreet" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorStreet" runat="server" ErrorMessage="Ulica może zawierać tylko litery od A-Z" ValidationExpression="^[a-zA-Z\s-żźćńółęąśŻŹĆĄŚĘŁÓŃ.]+$" ControlToValidate="TextBoxStreet" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Numer budynku
                </td>
                <td>
                    <asp:TextBox ID="TextBoxBuildingNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBuildingNumber" runat="server" ErrorMessage="Pole tekstowe numer budyku nie może być puste" ControlToValidate="TextBoxBuildingNumber" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorBuildingNumber" runat="server" ErrorMessage="Numer budynku może zawierać tylko cyfry" ValidationExpression="[0-9]+" ControlToValidate="TextBoxBuildingNumber" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Numer lokalu
                </td>
                <td>
                    <asp:TextBox ID="TextBoxApartmentNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidorApartmentNumber" runat="server" ErrorMessage="Pole tekstowe numer mieszkania nie może być puste" ControlToValidate="TextBoxApartmentNumber" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorApartmentNumber" runat="server" ErrorMessage="Numer mieszkania może zawierać tylko cyfry" ValidationExpression="[0-9]+" ControlToValidate="TextBoxApartmentNumber" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Kod pocztowy
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostcode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPostcode" runat="server" ErrorMessage="Pole tekstowe kod pocztowy nie może być puste" ControlToValidate="TextBoxPostcode" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPostcode" runat="server" ErrorMessage="Kod pocztowy musi być w formacie 00-000" ValidationExpression="^[0-9]{2}-[0-9]{3}$" ControlToValidate="TextBoxPostcode" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Miejscowość
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ErrorMessage="Pole tekstowe miasto nie może być puste" ControlToValidate="TextBoxCity" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Miasto może zawierać tylko litery od A-Z" ValidationExpression="^[a-zA-Z\s-żźćńółęąśŻŹĆĄŚĘŁÓŃ.]+$" ControlToValidate="TextBoxCity" Display="Dynamic" ForeColor="Red" ValidationGroup="registration">*</asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>
                    Hasło
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Pole tekstowe hasło nie może być puste" ControlToValidate="TextBoxPassword" ForeColor="Red" ValidationGroup="registration">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="registration" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ButtonAddNewAccount" runat="server" Text="Zarejestruj" OnClick="ButtonAddNewAccount_Click" ValidationGroup="registration" />
                </td>
            </tr>
                <tr>
                    <td>
                    <asp:Label ID="LabelStatus" runat="server" ForeColor="#00CC00"></asp:Label>
                </td>
                </tr>
        </table>
        </div>

        
        

        <div style="width: 50%;  vertical-align: middle;float:right">
            <table style="margin-right: auto; margin-left: auto;">
                <tr>
                    <td>
                        <h3>Zaloguj się</h3>
                    </td>
                </tr>
            <tr>
                <td>
                    Numer klienta
                </td>
                <td>
                    <asp:TextBox ID="TextBoxClientNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorClientNumber" runat="server" ErrorMessage="Pole tekstowe numer klienta nie może być puste" ControlToValidate="TextBoxClientNumber" ForeColor="Red" ValidationGroup="login" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorClientNumber" runat="server" ErrorMessage="Numer klienta może zawierać tylko cyfry od 0 do 9" ControlToValidate="TextBoxClientNumber" ValidationExpression="^[0-9]+$" ForeColor="Red" ValidationGroup="login" Display="Dynamic">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Hasło
                </td>
                <td>
                    <asp:TextBox ID="TextBoxClientPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPasswordLogin" runat="server" ErrorMessage="Pole tekstowe hasło nie może być puste" ControlToValidate="TextBoxClientPassword" ForeColor="Red" ValidationGroup="login" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="login" Width="259px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonAuthenticateUser" runat="server" Text="Zaloguj" OnClick="ButtonAuthenticateUser_Click" ValidationGroup="login" />
                </td>
            </tr>
        </table>
        </div>
        </div>
        
    </div>
    </form>
</body>
</html>
