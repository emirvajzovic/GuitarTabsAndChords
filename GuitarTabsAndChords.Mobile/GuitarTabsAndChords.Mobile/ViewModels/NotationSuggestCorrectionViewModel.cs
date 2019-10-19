using GuitarTabsAndChords.Mobile.Models;
using GuitarTabsAndChords.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile.ViewModels
{
    public class NotationSuggestCorrectionViewModel : BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceNotationCorrections = new APIService("NotationCorrections");
        private int _notationId;

        private Model.Notations _notation;
        public Model.Notations Notation
        {
            get { return _notation; }
            set { SetProperty(ref _notation, value); }
        }

        private string _lastEditInfo;
        public string LastEditInfo
        {
            get { return _lastEditInfo; }
            set { SetProperty(ref _lastEditInfo, value); }
        }

        private Command InitCommand;
        public ICommand SuggestCorrectionCommand { get; set; }
        public INavigation Navigation { get; }

        public NotationSuggestCorrectionViewModel(int NotationId, INavigation navigation)
        {
            Title = "Suggest correction";

            _notationId = NotationId;
            Navigation = navigation;
            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);

            SuggestCorrectionCommand = new Command(async () => await SuggestCorrection());
        }

        private async Task SuggestCorrection()
        {
            var request = new Model.Requests.NotationCorrectionsInsertRequest
            {
                NotationId = _notationId,
                NotationContent = Notation.NotationContent
            };
            var entity = _serviceNotationCorrections.Insert<Model.NotationCorrections>(request);
            if(entity != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Your suggestion is awaiting review", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Your suggestion could not be saved.", "OK");
            }

        }

        public async Task Init()
        {
            await LoadNotation();
        }

        private async Task LoadNotation()
        {
            Notation = await _serviceNotations.GetById<Model.Notations>(_notationId);
            LastEditInfo = "on " + Notation.LastEditted.ToShortDateString();
        }

    }
}
