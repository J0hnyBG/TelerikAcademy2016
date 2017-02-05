using System;
using System.Web.UI;

using _02_Todo.Data;
using _02_Todo.Data.Models;

namespace _02_Todo
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var name = this.TbCategoryName.Text;
            var cat = new Category()
                      {
                          Name = name
                      };
            var ds = new TodoAppDbContext();
            ds.Categories.Add(cat);
            ds.SaveChanges();
        }
    }
}
