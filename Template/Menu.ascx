﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="PocketMoney.Template.Menu" %>
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
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SiteMapDataSource1" >
                    <ItemTemplate>
                        <li <%# Eval("URL") == SiteMap.CurrentNode.Url ? "class=\"active\"" : "" %>>
                            <a href="<%# Eval("URL") %>"><%# Eval("Title") %></a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>