using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using _02_Todo.Data;

namespace _02_Todo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.QueryString["CategoryId"] == null)
            {
                this.TodoDataSource.WhereParameters.Clear();
            }
        }
    }
}
