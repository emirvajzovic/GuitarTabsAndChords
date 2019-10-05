using GuitarTabsAndChords.Mobile.Models;
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
    public class NotationDetailsViewModel: BaseViewModel
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
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
        public ICommand OcijeniStarCommand { get; set; }

        public int Ocjena { get; set; }

        #region stars

        private Star _star1;
        public Star Star1
        {
            get { return _star1; }
            set { SetProperty(ref _star1, value); }
        }
        private Star _star2;
        public Star Star2
        {
            get { return _star2; }
            set { SetProperty(ref _star2, value); }
        }
        private Star _star3;
        public Star Star3
        {
            get { return _star3; }
            set { SetProperty(ref _star3, value); }
        }
        private Star _star4;
        public Star Star4
        {
            get { return _star4; }
            set { SetProperty(ref _star4, value); }
        }
        private Star _star5;
        public Star Star5
        {
            get { return _star5; }
            set { SetProperty(ref _star5, value); }
        }

        #endregion

        public NotationDetailsViewModel(int NotationId)
        {
            Title = "Notation Details";
            _notationId = NotationId;

            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);

            OcijeniStarCommand = new Command<string>(async (ocjena) => await OcijeniStar(ocjena));

            Star1 = new Star();
            Star2 = new Star();
            Star3 = new Star();
            Star4 = new Star();
            Star5 = new Star();
        }

        private async Task Init()
        {
            Notation = await _serviceNotations.GetById<Model.Notations>(_notationId);
            LastEditInfo = Notation.LastEditor.Username + " on " + Notation.LastEditted.ToShortDateString();

            UpdateZvjezdice();
        }


        private void UpdateZvjezdice()
        {
            var star_emptyinside = new Star { Slika = "star_empty.png" };
            var Star_Filled = new Star { Slika = "star_filled.png" };

            Star1 = star_emptyinside;
            Star2 = star_emptyinside;
            Star3 = star_emptyinside;
            Star4 = star_emptyinside;
            Star5 = star_emptyinside;

            if (Ocjena >= 1)
                Star1 = Star_Filled;
            if (Ocjena >= 2)
                Star2 = Star_Filled;
            if (Ocjena >= 3)
                Star3 = Star_Filled;
            if (Ocjena >= 4)
                Star4 = Star_Filled;
            if (Ocjena == 5)
                Star5 = Star_Filled;
        }


        private async Task OcijeniStar(string ocjena)
        {
            int OcjenaBroj = int.TryParse(ocjena, out int value) ? value : 0;
            if (OcjenaBroj >= 1 && OcjenaBroj <= 5)
            {

                //var request = new Model.Requests.OcjeneInsertRequest
                //{
                //    IgraId = _igraId,
                //    Ocjena = OcjenaBroj
                //};

                //Ocjena = OcjenaBroj;

                //UpdateZvjezdice();

                //await _serviceOcjene.Insert<Model.Ocjene>(request, "OcijeniIgru");

                //await UcitajIgraDetails();
            }
        }

    }
}
