<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Template/Site.master" CodeBehind="transactions.aspx.cs" Inherits="PocketMoney.transactions" %>


<asp:Content ID="cont" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="row">
    <div class="col-xs-12 col-xs-12">

      <div id="ctl00_ContentPlaceHolder1_BootstrapPanel6" class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title" style="font-weight: normal" id="h3Title" runat="server"></h3>
          <div class="actions pull-right"><i class="fa fa-chevron-down"></i></div>
        </div>
        <div class="panel-body" style="">
          <div class=" col-lg-12 col-md-12 col-sm-12 col-xs-12" id="contacts_container">
            <table id="contacts" class="table table-striped table-condensed" cellspacing="0" width="100%">
              <thead>
                <tr>
                  <th class="col-xs-3">Date
                  </th>
                  <th class="col-xs-6">Description
                  </th>
                  <th class="col-xs-3">Amount
                  </th>
                </tr>
              </thead>
              <asp:Repeater ID="rptrTransactions" runat="server">
                <ItemTemplate>
                  <tr id="tr1" runat="server">
                    <td valign="top">
                      <%# ((DateTime)Eval("TimeStamp")).ToString("dd MMM") %>
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
