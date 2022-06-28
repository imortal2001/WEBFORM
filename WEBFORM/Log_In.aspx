<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Log_In.aspx.cs" Inherits="WEBFORM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Log In</h3>

    <table class="nav-justified">
        <tr>
            <td style="width: 200px">
                
                Username
                <asp:TextBox ID="txtUser" runat="server" PlaceHolder="Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="usrValidator" runat="server" ControlToValidate="txtUser" ErrorMessage="Username is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="userName" runat="server" CssClass="text-danger" ErrorMessage="Invalid Username Format!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUser"></asp:RegularExpressionValidator>
                 <br /><br />
                Password
                <asp:TextBox ID="txtPass" TextMode="Password" runat="server" PlaceHolder="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="passValidator" runat="server" ControlToValidate="txtPass" ErrorMessage="Password is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="passWord" runat="server" CssClass="text-danger" ErrorMessage="Invalid Password Format!" ValidationExpression="(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w])(?!.*\s)^.{8,16}$" ControlToValidate="txtPass"></asp:RegularExpressionValidator>
                 
                <br /><br />
                <asp:Button ID="btn1" runat="server" Text="Log In" Height="25px" Width="59px" OnClick="btn_logIn" />
            </td> 
 
    </table>

</asp:Content>
