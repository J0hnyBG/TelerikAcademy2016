using System;
using System.Linq;

using WebFormsMvp;

using _01_Cars.CustomEventArgs.Contracts;
using _01_Cars.Models.Enums;
using _01_Cars.Presenters.Contracts;
using _01_Cars.Services.Contracts;
using _01_Cars.Views;

namespace _01_Cars.Presenters
{
    public class SearchCarsPresenter : Presenter<ISearchCarsView>, ISearchCarsPresenter
    {
        private readonly ISearchCarsView view;
        private readonly ICarService carService;

        public SearchCarsPresenter(ISearchCarsView view, ICarService carService)
            : base(view)
        {
            this.view = view;
            this.carService = carService;

            this.view.OnInitialize += this.OnInitialize;
            this.view.OnFormSubmit += this.OnFormSubmit;
            this.view.OnProducerSelectionChanged += this.OnProducerSelectionChanged;
        }

        private void OnFormSubmit(object sender, ICarSearchEventArgs args)
        {
            var engineType = (EngineType)Enum.Parse(typeof(EngineType), args.SelectedEngine, true);
            var extras = args.SelectedExtras.Select(e => (Extra)Enum.Parse(typeof(Extra), e, true)).ToList();

            this.view.Model.FoundCars = this.carService.FindCars(args.SelectedProducer,
                                                                 args.SelectedModel,
                                                                 engineType,
                                                                 extras);
        }

        private void OnProducerSelectionChanged(object sender, IProducerSelectionEventArgs args)
        {
            var models = this.carService.FindModelsForProducer(args.SelectedProducer);
            this.view.Model.Models = models.Select(m => m.Name).Distinct().ToList();
        }

        private void OnInitialize(object sender, EventArgs args)
        {
            this.view.Model.Producers = this.carService.GetAllProducerNames();
            this.view.Model.Models = this.carService.GetAllModelNames();
            this.view.Model.Extras = this.carService.GetAllExtras();
            this.view.Model.EngineTypes = this.carService.GetAllEngineTypes();
        }
    }
}
