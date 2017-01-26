using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_Escaping
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_OnClick(object sender, EventArgs e)
        {
            this.Result.Text = HttpUtility.HtmlEncode(this.TextBox.Text);
        }
    }
}