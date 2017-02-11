using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;

namespace _01_Links.UserControls
{
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        public IEnumerable<IMenuLink> DataSource
        {
            get
            {
                return this.LinkMenuList.DataSource as IEnumerable<IMenuLink>;
            }

            set
            {
                this.LinkMenuList.DataSource = value;
            }
        }

        public string FontFamily { get; set; }

        public Color FontColor { get; set; }

        public FontUnit FontSize { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}