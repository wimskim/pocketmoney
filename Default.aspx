﻿<%@ Page Language="C#" MasterPageFile="~/Template/Site.master" AutoEventWireup="true"
  CodeBehind="Default.aspx.cs" Inherits="PocketMoney.Default" %>

<asp:Content ID="cont" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <div class="row">
    <div class="col-xs-12 col-xs-12">

      <div id="ctl00_ContentPlaceHolder1_BootstrapPanel6" class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title" style="font-weight: normal">Accounts</h3>
          <div class="actions pull-right"><i class="fa fa-chevron-down"></i></div>
        </div>
        <div class="panel-body" style="">
          <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12" id="contacts_container">
            <table id="contacts" class="table table-striped table-condensed" cellspacing="0" width="100%">
              <thead>
                <tr>
                  <th class="col-xs-9">Name
                  </th>
                  <th class="col-xs-3">Balance
                  </th>
                </tr>
              </thead>
              <asp:Repeater ID="rptrAccounts" runat="server">
                <ItemTemplate>
                  <tr id="trRow" runat="server">
                    <td valign="top">
                      <a href="transactions.aspx?i=<%# Eval("Id") %>"><%# Eval("Name") %></a>
                    </td>
                    <td valign="top">R <%# decimal.Round((decimal)Eval("Balance"), 2).ToString() %>
                    </td>
                  </tr>
                </ItemTemplate>
              </asp:Repeater>
            </table>
          </div>
        </div>
      </div>
    </div>

  </div>
  <div class="row">
    <div class="col-xs-12 col-xs-12">

      <div id="ctl00_ContentPlaceHolder1_BootstrapPanel6" class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title" style="font-weight: normal">Today</h3>
          <div class="actions pull-right"><i class="fa fa-chevron-down"></i></div>
        </div>
        <div class="panel-body" style="">
          <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12" id="contacts_container">
            <table id="contacts" class="table table-striped table-condensed" cellspacing="0" width="100%">
              <thead>
                <tr>
                  <th class="col-xs-3">Account
                  </th>
                  <th class="col-xs-6">Description
                  </th>
                  <th class="col-xs-3">Amount
                  </th>
                </tr>
              </thead>
              <asp:Repeater ID="rptrToday" runat="server">
                <ItemTemplate>
                  <tr id="trRow" runat="server">
                    <td valign="top">
                      <a href="transactions.aspx?i=<%# Eval("AccountId") %>"><%# Eval("AccountName") %></a>
                    </td>
                    <td valign="top">
                      <%# Eval("Description") %>
                    </td>
                    <td valign="top">R <%# decimal.Round((decimal)Eval("Amount"), 2).ToString() %>
                    </td>
                  </tr>
                </ItemTemplate>
              </asp:Repeater>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
