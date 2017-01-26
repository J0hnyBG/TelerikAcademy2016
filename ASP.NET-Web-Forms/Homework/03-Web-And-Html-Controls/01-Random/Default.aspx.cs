using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_Random
{
    public partial class _Default : Page
    {
        private Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitHtmlForm_OnServerClick(object sender, EventArgs e)
        {
            try
            {
                var from = int.Parse(this.HtmlFrom.Value);
                var to = int.Parse(this.HtmlTo.Value);

                this.HtmlResult.InnerHtml = this.rand.Next(from, to).ToString();
            }
            catch (Exception ex)
            {
                this.ErrorResult.InnerHtml = ex.Message;
            }
        }

        protected void SubmitWebForm_OnClick(object sender, EventArgs e)
        {
            try
            {
                var from = int.Parse(this.WebFrom.Text);
                var to = int.Parse(this.WebTo.Text);

                this.WebResult.InnerHtml = this.rand.Next(from, to).ToString();
            }
            catch (Exception ex)
            {
                this.ErrorResult.InnerHtml = ex.Message;
            }
        }
    }
}
