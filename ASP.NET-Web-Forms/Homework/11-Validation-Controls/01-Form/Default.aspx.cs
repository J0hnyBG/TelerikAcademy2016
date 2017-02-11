using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_Form
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.Accept.Checked;
        }

        protected void GenderList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var value = this.GenderList.SelectedValue;
            if (value == "Male")
            {
                this.Female.Visible = false;
                this.Male.Visible = true;
            }
            else
            {
                this.Female.Visible = true;
                this.Male.Visible = false;
            }
        }
    }
}