using GuitarTabsAndChords.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarTabsAndChords.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotationDetailsPage : ContentPage
    {
        private NotationDetailsViewModel VM;

        public NotationDetailsPage(int NotationId)
        {
            InitializeComponent();
            BindingContext = VM = new NotationDetailsViewModel(NotationId);
        }

    }
}