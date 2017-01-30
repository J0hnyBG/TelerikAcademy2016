using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Ninject;

using WebFormsMvp;
using WebFormsMvp.Web;

using _01_Cars.CustomEventArgs.Contracts;
using _01_Cars.CustomEventArgs.Factories;
using _01_Cars.Models.Contracts;
using _01_Cars.Presenters.Contracts;
using _01_Cars.ViewModels;
using _01_Cars.Views;

namespace _01_Cars
{
    [PresenterBinding(typeof(ISearchCarsPresenter))]
    public partial class _Default : MvpPage<SearchCarsViewModel>, ISearchCarsView
    {
        public event EventHandler<EventArgs> OnInitialize;

        public event EventHandler<ICarSearchEventArgs> OnFormSubmit;

        public event EventHandler<IProducerSelectionEventArgs> OnProducerSelectionChanged;

        [Inject]
        public ICustomEventArgsFactory EventArgsFactory { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.OnInitialize?.Invoke(null, null);

                this.ProducerDropDownList.DataSource = this.Model.Producers;
                this.ProducerDropDownList.DataBind();

                this.ModelDropDownList.DataSource = this.Model.Models;
                this.ModelDropDownList.DataBind();

                this.ExtrasCheckBoxList.DataSource = this.Model.Extras;
                this.ExtrasCheckBoxList.DataBind();

                this.EngineRadioButtonList.DataSource = this.Model.EngineTypes;
                this.EngineRadioButtonList.DataBind();
            }
        }

        protected virtual void ProducerChanged(object sender, EventArgs args)
        {
            var selectedProducer = this.ProducerDropDownList.SelectedItem.Text;
            var eventArgs = this.EventArgsFactory.CreateProducerSelectionEventArgs(selectedProducer);
            this.OnProducerSelectionChanged?.Invoke(null, eventArgs);

            this.ModelDropDownList.DataSource = this.Model.Models;
            this.ModelDropDownList.DataBind();
        }

        protected virtual void SearchCarsSubmit(object sender, EventArgs args)
        {
            var producer = this.ProducerDropDownList.SelectedItem.Text;
            var model = this.ModelDropDownList.SelectedItem.Text;
            var engine = this.EngineRadioButtonList.SelectedValue;

            var extras = new LinkedList<string>();
            foreach (ListItem item in this.ExtrasCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    extras.AddLast(item.Text);
                }
            }

            var createCarFormSubmitEventArgs = this.EventArgsFactory.CreateCarSearchEventArgs(producer,
                                                                                              model,
                                                                                              engine,
                                                                                              extras);

            this.OnFormSubmit?.Invoke(null, createCarFormSubmitEventArgs);

            this.ResultsRepeater.DataSource = this.Model.FoundCars;
            this.ResultsRepeater.DataBind();
        }

        protected void CarRepeaterDataBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType != ListItemType.Item && args.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            var childRepeater = (Repeater)args.Item.FindControl("ExtrasRepeater");
            childRepeater.DataSource = ((ICarModel)args.Item.DataItem).Extras;
            childRepeater.DataBind();
        }
    }
}
