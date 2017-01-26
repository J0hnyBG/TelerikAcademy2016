using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ninject;

using _03_Students.Models;

namespace _03_Students
{
    public partial class _Default : Page
    {
        [Inject]
        public University StudentRepo { protected get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Students.DataSource = this.StudentRepo.Students;
            this.Students.DataBind();
        }

        protected void CreateStudent_OnClick(object sender, EventArgs e)
        {
            var firstName = this.FirstName.Text;
            var lastName = this.LastName.Text;
            var studentNumber = this.Number.Text;
            var university = this.University.Text;
            var selectedCourses = this.Courses.GetSelectedIndices()
                                      .Select(i => this.Courses.Items[i].Value)
                                      .ToList();

            var student = new Student()
                          {
                              FirstName = firstName,
                              LastName = lastName,
                              University = university,
                              Courses = selectedCourses,
                              Number = studentNumber
                          };

            this.StudentRepo.Students.Add(student);
        }
    }
}
