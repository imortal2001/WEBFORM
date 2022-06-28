<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WEBFORM.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Create Account</h3><br /><br />
    Lastname <br />
    <asp:TextBox ID="lName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLname" runat="server" ErrorMessage="Lastname is Required" CssClass="text-danger" ControlToValidate="lName"></asp:RequiredFieldValidator>
    <br />
    Firstname <br />
    <asp:TextBox ID="fName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFname" runat="server" ControlToValidate="fName" ErrorMessage="Firstname is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
    <br />
    Mobile Number<br />
    <asp:TextBox ID="mobNum" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="numValidator" runat="server" ErrorMessage="Invalid Phone Number!" ValidationExpression="^(09|\+639)\d{9}$" ControlToValidate="mobNum"></asp:RegularExpressionValidator>
    <br />
    
    Username<br />
    <asp:TextBox ID="user" runat="server">
    </asp:TextBox><asp:RegularExpressionValidator ID="userName" runat="server" CssClass="text-danger" ErrorMessage="Invalid Username Format!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="user"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="usrValidator" runat="server" ControlToValidate="user" ErrorMessage="Username is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:Label ID="UsernameError" runat="server" Text="" CssClass="text-danger" Display="Dynamic"></asp:Label>
    <br /><br />

    BirthDate<br />
    <asp:TextBox ID="birthDate" runat="server"></asp:TextBox>
    <asp:ImageButton ID="imgbtncldr" runat="server" Height="25px" ImageUrl="img/calendar.png" OnClick="imgbtncldr_Click" Width="25px" />
    <asp:Calendar ID="clndrbdate" runat="server" OnDayRender="clndrbdate_DayRender" OnSelectionChanged="clndrbdate_SelectionChanged"></asp:Calendar>
 
    <br /><br />
     Password<br />
     <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="passValidator" runat="server" ControlToValidate="pass" ErrorMessage="Password is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="password" runat="server" ErrorMessage="Password length must be minimum of 8 characters" Display="Dynamic" CssClass="text-danger" ControlToValidate="pass" ValidationExpression="(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w])(?!.*\s)^.{8,16}$"></asp:RegularExpressionValidator>
    <br /><br />
    Confirm Password <br />
    <asp:TextBox ID="conPass" runat="server" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="comPass" runat="server" ErrorMessage="Password did not match!" CssClass="text-danger" ControlToCompare="pass" ControlToValidate="conPass"></asp:CompareValidator>
    <br /><br />

    
    <asp:Button ID="btn" runat="server" Text="Confirm" OnClick="btn_Click" />



</asp:Content>
