using System;
using System.Web.UI;

using Ninject;

using _01_WebForms.Business;
using _01_WebForms.Common.Contracts;

namespace _01_WebForms
{
    public partial class Default : Page, ISumatorPageView
    {
        private ISumatorPresenter sumator;

        [Inject]
        public ISumatorPresenter Sumator {
            get
            {
                return this.sumator;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Sumator));
                }

                this.sumator = value;
                this.sumator.View = this;
            }
        }

        public string TextBox1Text
        {
            get { return this.TextBox1.Text; }
            set { this.TextBox1.Text = value; }
        }

        public string TextBox2Text
        {
            get { return this.TextBox2.Text; }
            set { this.TextBox2.Text = value; }
        }

        public string ResultText
        {
            get { return this.Result.Text; }
            set { this.Result.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SumNumbers_Click(object sender, EventArgs e)
        {
            this.Sumator.CalculateSum();
        }
    }
}
