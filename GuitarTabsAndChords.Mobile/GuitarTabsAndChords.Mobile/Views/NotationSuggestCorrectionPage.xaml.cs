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
    public partial class NotationSuggestCorrectionPage : ContentPage
    {
        private NotationSuggestCorrectionViewModel VM;

        public NotationSuggestCorrectionPage(int NotationId)
        {
            InitializeComponent();
            BindingContext = VM = new NotationSuggestCorrectionViewModel(NotationId, Navigation);
        }

    }
}