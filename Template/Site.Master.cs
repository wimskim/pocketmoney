﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocketMoney.Template
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string PageTitle
        {
            get { return pageTitle.InnerHtml; }
            set { pageTitle.InnerHtml = value; }
        }

    }
}