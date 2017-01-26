using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05_Calculator
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnNumberClickedCommand(object sender, CommandEventArgs e)
        {
            this.Result.Text = this.Result.Text + e.CommandArgument;
        }

        protected void OnOperationClickedCommand(object sender, CommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Previous.Text))
            {
                this.OnCalculateCommand(sender, e);
                return;
            }

            if ((string)e.CommandArgument == "sqrt")
            {
                this.Result.Text = (Math.Sqrt(double.Parse(this.Result.Text))).ToString();
                return;
            }

            this.Operation.Text = (string)e.CommandArgument;
            this.Previous.Text = this.Result.Text;
            this.Result.Text = "";
        }

        protected void OnClearClickedCommand(object sender, CommandEventArgs e)
        {
            this.Operation.Text = "";
            this.Previous.Text = "";
            this.Result.Text = "";
        }

        protected void OnCalculateCommand(object sender, CommandEventArgs e)
        {
            if (this.Previous.Text == "")
            {
                return;
            }

            var first = double.Parse(this.Previous.Text);
            var second = double.Parse(this.Result.Text);
            this.Previous.Text = "";

            switch (this.Operation.Text)
            {
                case "*":
                    this.Result.Text = (first * second).ToString();
                    break;
                case "-":
                    this.Result.Text = (first - second).ToString();

                    break;
                case "+":
                    this.Result.Text = (first + second).ToString();

                    break;
                case "/":
                    if (second == 0)
                    {
                        this.ErrorLabel.Text = "You cannot divide by zero!";
                        return;
                    }

                    this.Result.Text = (first / second).ToString();

                    break;
            }
        }
    }
}
