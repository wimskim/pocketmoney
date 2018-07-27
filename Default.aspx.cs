using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocketMoney
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPage();

        }
        private void BindPage()
        {

            rptrAccounts.DataSource = BLL.AccountCollection.GetAll();
            rptrAccounts.DataBind();

        }



    }
}