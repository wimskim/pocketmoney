<%@ Page Language="C#" MasterPageFile="~/Template/Site.master" AutoEventWireup="true"
  CodeBehind="addtransaction.aspx.cs" Inherits="PocketMoney.addtransaction" %>

<asp:Content ID="cont" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <div class="row">
    <div class="col-xs-12 col-xs-12">

      <div id="ctl00_ContentPlaceHolder1_BootstrapPanel6" class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title" style="font-weight: normal">Add Transaction</h3>
          <div class="actions pull-right"><i class="fa fa-chevron-down"></i></div>
        </div>
        <div class="panel-body" style="">
          <div class="form-horizontal" role="form">
            <div class="form-group">
              <label class="col-sm-4 control-label">
                Account</label>
              <div class="col-sm-8">
                <select class="form-control" id="ddAccounts" runat="server" />
              </div>
            </div>
            <div class="form-group">
              <label class="col-sm-4 control-label">
                Description</label>
              <div class="col-sm-8">
                <input type="text" class="form-control" id="txtDescription" runat="server" placeholder="" />
              </div>
            </div>
            <div class="form-group">
              <label class="col-sm-4 control-label">
                Amount</label>
              <div class="col-sm-8">
                <input type="text" class="form-control" id="txtAmount" runat="server" placeholder="" />
              </div>
            </div>
            <div class="form-group">
              <label class="col-sm-12 control-label" style="color:red;" runat="server" visible="false" id="lblError">

                Error message
                </label>
              
            </div>
             <div class="form-group">
              <label class="col-sm-4 control-label">
                </label>
              <div class="col-sm-8 pull-right">
                  <asp:LinkButton ID="lnkSave" runat="server" CssClass="btn btn-success" OnClick="lnkSave_Click">Save</asp:LinkButton>
              </div>
            </div>

             
          </div>

        </div>
      </div>
    </div>
</asp:Content>
