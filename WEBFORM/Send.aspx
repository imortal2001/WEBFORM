<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="WEBFORM.Send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"><div><link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
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

	<%--Content Here--%>
        <h3>Transfer Money</h3>

            Send To:<asp:TextBox ID="userTransfer" runat="server"></asp:TextBox> 
	<asp:RequiredFieldValidator ID="usrValidator" runat="server" ControlToValidate="userTransfer" ErrorMessage="Username is Required" CssClass="text-danger"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="userName" runat="server" CssClass="text-danger" ErrorMessage="Invalid Username Format!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="userTransfer"></asp:RegularExpressionValidator>
               
           <%--// Receiver ID: <asp:TextBox ID="receiverID" runat="server"></asp:TextBox>--%>
            </br>
            Amount: $<asp:TextBox ID="amount" runat="server"></asp:TextBox> 
		<asp:RequiredFieldValidator ID="Amt1" runat="server" ErrorMessage="Input Required" CssClass="text-danger" ControlToValidate="amount"></asp:RequiredFieldValidator>
           <asp:Label ID="errorMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
	</br>
		
        <asp:Button ID="sendBtn" runat="server" Text="Send" OnClick="btn_Send" />
		

	</div>
		
    </form>
</body>
</html>
