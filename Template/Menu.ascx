<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="PocketMoney.Template.Menu" %>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" StartingNodeUrl="~/default.aspx"  />
<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">

            <a runat="server" id="aHome" href="~/"><h3 class="navbar-brand" >PocketMoney</h3></a>
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>
        <div class="collapse navbar-collapse">
            <ul class="nav navbar-nav navbar-left">
                <li>
                    <a href="addtransaction.aspx">Add Transaction</a>
                </li>
            </ul>
        </div>
    </div>
</div>