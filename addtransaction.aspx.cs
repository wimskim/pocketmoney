using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocketMoney
{
    public partial class addtransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                BindPage();

        }
        private void BindPage()
        {
            ddAccounts.DataSource = BLL.AccountCollection.GetAll();
            ddAccounts.DataTextField = "Name";
            ddAccounts.DataValueField = "Id";
            ddAccounts.DataBind();
            ddAccounts.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Transaction trans = new BLL.Transaction();
                int accountId = 0;
                if (!int.TryParse(ddAccounts.Items[ddAccounts.SelectedIndex].Value, out accountId))
                    throw new Exception("No account selected");

                trans.AccountId = accountId;
                trans.Description = txtDescription.Value;
                trans.Amount = decimal.Parse(txtAmount.Value) * -1;
                trans.Timestamp = DateTime.Now;

                trans.Save();

                Response.Redirect("~/");

            }
            catch(Exception ex)
            {
                lblError.InnerText = ex.Message;
                lblError.Visible = true;
            }
        }
    }
}