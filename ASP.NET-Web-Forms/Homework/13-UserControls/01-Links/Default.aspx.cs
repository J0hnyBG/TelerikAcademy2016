using System;
using System.Collections.Generic;
using System.Web.UI;

using _01_Links.UserControls;

namespace _01_Links
{
    public partial class _Default : Page
    {
        protected readonly IEnumerable<IMenuLink> Links = new List<IMenuLink>()
                                           {
                                               new MenuLink() { Url = "/#0", Title = "Title 0"},
                                               new MenuLink() { Url = "/#1", Title = "Title 1"},
                                               new MenuLink() { Url = "/#2", Title = "Title 2"},
                                               new MenuLink() { Url = "/#3", Title = "Title 3"},
                                               new MenuLink() { Url = "/#4", Title = "Title 4"},
                                               new MenuLink() { Url = "/#5", Title = "Title 5"}
                                           };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LinkMenu.DataSource = this.Links;
            this.LinkMenu.DataBind();
        }
    }
}