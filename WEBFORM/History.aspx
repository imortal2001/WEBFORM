<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="WEBFORM.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
        <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
        <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
		<script type="text/javascript" src="Content/StyleSheet1.css"></script>
		<script type="text/javascript" src="Scripts/WebForms/JavaScript.js"></script>
<!------ Include the above in your HEAD tag ---------->

<nav class="navbar navbar-inverse sidebar" role="navigation">
    <div class="container-fluid">
		<!-- Brand and toggle get grouped for better mobile display -->
		<div class="navbar-header">
			<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-sidebar-navbar-collapse-1">
				<span class="sr-only">Toggle navigation</span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
				<span class="icon-bar"></span>
			</button>
			<a class="navbar-brand" href="Dashboard.aspx">Home</a>
		</div>
		<!-- Collect the nav links, forms, and other content for toggling -->
		<div class="collapse navbar-collapse" id="bs-sidebar-navbar-collapse-1">
			<ul class="nav navbar-nav">

                 <li class="active"><a href="History.aspx">Transaction History <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-header"></span></a></li>
                <li class="active"><a href="Deposit.aspx">Deposit <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-usd"></span></a></li>
                 <li class="active"><a href="Withdraw.aspx">Withdraw <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-usd"></span></a></li>
               <li class="active"><a href="Send.aspx">Money Transfer <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-usd"></span></a></li>
				<li class="active"><a href="Log out.aspx">Log Out <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-off"></span></a></li>
			    
			</ul>
				
		</div>
	</div>
</nav>
<div class="main">

<!-- Content Here -->
	<h3>My Statement of Accounts</h3>
    <br />
    <br /><br />
        <asp:Button ID="btn" runat="server" Text="View All" OnClick="btn_Click" />
    
     <asp:Button ID="btnCustom" runat="server" Text="Custom" OnClick="custom_Click" />
     <asp:TextBox ID="searchBox" runat="server"></asp:TextBox>

    <asp:Button ID="customEnter" runat="server" Text="Search" OnClick="custom_Display"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="cancel_Click"/>
    <br /><br />
    <asp:GridView ID="gvMyAccnt" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" FooterStyle-BorderStyle="Double" FooterStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="Email" ItemStyle-Width="150px" />
            <asp:BoundField DataField="ID" HeaderText="Transaction ID" ItemStyle-Width="100px" />
            <asp:BoundField DataField="amt" HeaderText="Amount" ItemStyle-Width="150px" />
             <asp:BoundField DataField="typ" HeaderText="Transaction Type" ItemStyle-Width="150px" />
             <asp:BoundField DataField="tdate" HeaderText="Transaction Date" ItemStyle-Width="200px" />
            
            
        </Columns>
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    
</div>
        </div>
    </form>
</body>
</html>
 