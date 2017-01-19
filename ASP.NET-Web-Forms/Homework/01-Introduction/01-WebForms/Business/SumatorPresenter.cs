using System;

using _01_WebForms.Common.Contracts;

namespace _01_WebForms.Business
{
    public class SumatorPresenter : ISumatorPresenter
    {
        private ISumatorPageView view;

        public ISumatorPageView View
        {
            get
            {
                return this.view;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.View));
                }

                this.view = value;
            }
        }

        public void CalculateSum()
        {
            try
            {
                var firstNumber = int.Parse(this.View.TextBox1Text);
                var secondNumber = int.Parse(this.View.TextBox2Text);

                this.View.ResultText = (firstNumber + secondNumber).ToString();
            }
            catch (Exception exception)
            {
                this.View.ResultText = exception.Message;
            }
        }
    }
}
