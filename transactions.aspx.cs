using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocketMoney
{
    public partial class transactions : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPage();
        }
        private void BindPage()
        {
            BLL.Account acc = BLL.Account.GetById(int.Parse(Request["i"]));

            h3Title.InnerText = acc.Name;

            rptrTransactions.DataSource = BLL.TransactionCollection.GetByAccount(acc.Id);
            rptrTransactions.DataBind();
        }
    }
}