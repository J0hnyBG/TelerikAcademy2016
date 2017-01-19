using System;
using System.Web.UI;

namespace _01_Hello
{
    public partial class _Default : Page
    {
        public _Default()
        {
            this.InitComplete += Page_InitComplete;
            this.LoadComplete += Page_LoadComplete;
            this.PreLoad += Page_PreLoad;
            this.SaveStateComplete += Page_SaveStateComplete;
            this.Unload += Page_Unload;
            this.PreRenderComplete += Page_PreRenderComplete;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = this.TextBox1.Text;
            this.Result.Text = name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Page_Load invoked" + "<br/>");
            this.Hello.Text = "Hello from .cs";
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //this.Response.Write("Page_Unload invoked" + "<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreRenderComplete invoked" + "<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            this.Response.Write("Page_SaveStateComplete invoked" + "<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreLoad invoked" + "<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            this.Response.Write("Page_LoadComplete invoked" + "<br/>");
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreInit invoked" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Response.Write("Page_Init invoked" + "<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            this.Response.Write("Page_InitComplete invoked" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Response.Write("Page_PreRender invoked" + "<br/>");
        }
    }
}