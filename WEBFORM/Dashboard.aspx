<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WEBFORM.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <%-- <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/">Application name</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="GridView.aspx">Grid View</a></li>
                        
                    </ul>
                    </div>--%>


			<a class="navbar-brand" href="Dashboard.aspx">Home</a>
		</div>
		<!-- Collect the nav links, forms, and other content for toggling -->
		<div class="collapse navbar-collapse" id="bs-sidebar-navbar-collapse-1">
			<ul class="nav navbar-nav">

               
                <li class="active"><a href="History.aspx">Transaction History <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-header"></span></a></li>
                <li class="active"><a href="Deposit.aspx">Deposit <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-usd"></span></a></li>
                 <li class="active"><a href="Withdraw.aspx">Withdraw <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-usd"></span></a></li>
                <li class="active"><a href="Send.aspx">Money Transfer <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-off"></span></a></li>
                <li class="active"><a href="Log out.aspx">Log Out <span style="font-size:16px;" class="pull-right hidden-xs showopacity glyphicon glyphicon-off"></span></a></li>
			    
			</ul>
				
		</div>
	</div>
</nav>
<div class="main">

<!-- Content Here -->
     <div>
            <h5>Balance:<%Response.Write(Session["bal"]); %></h5>
        </div>
</div>
    </form>
</body>
</html>
