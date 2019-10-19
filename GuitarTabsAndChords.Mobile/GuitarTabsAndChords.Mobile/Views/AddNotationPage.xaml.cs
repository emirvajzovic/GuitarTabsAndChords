using GuitarTabsAndChords.Mobile.ViewModels;
using Syncfusion.XForms.ComboBox;
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
    public partial class AddNotationPage : ContentPage
    {
        private readonly AddNotationViewModel VM;


        public AddNotationPage()
        {
            InitializeComponent();
            BindingContext = VM = new AddNotationViewModel(Navigation);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.Init();
        }

        private void ArtistComboBox_ValueChanged(object sender, Syncfusion.XForms.ComboBox.ValueChangedEventArgs e)
        {
            SfComboBox cmb = sender as SfComboBox;
            if (cmb.SelectedItem == null)
            {
                VM.NoResultsFoundText = "No results found, click here to add artist " + e.Value;

                AlbumComboBox.SelectedItem = null;
                AlbumComboBox.Text = "";
                SongComboBox.SelectedItem = null;
                SongComboBox.Text = "";
                VM.AlbumList.Clear();
                VM.SongList.Clear();
            }
            VM.ArtistName = e.Value;
        }
        private async void ArtistComboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            SfComboBox cmb = sender as SfComboBox;

            Model.Artists artist = cmb.SelectedValue as Model.Artists;
            VM.ArtistId = artist.Id;
            await VM.LoadAlbums();

            AlbumComboBox.SelectedItem = null;
            AlbumComboBox.Text = "";
            SongComboBox.SelectedItem = null;
            SongComboBox.Text = "";
        }


        private void AlbumComboBox_ValueChanged(object sender, Syncfusion.XForms.ComboBox.ValueChangedEventArgs e)
        {
            SfComboBox cmb = sender as SfComboBox;
            if (cmb.SelectedItem == null)
            {
                VM.NoResultsFoundText = "No results found, click here to add album " + e.Value;
                SongComboBox.SelectedItem = null;
                SongComboBox.Text = "";
                VM.SongList.Clear();
            }
            VM.AlbumName = e.Value;
        }
        private async void AlbumComboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            SfComboBox cmb = sender as SfComboBox;

            Model.Albums album = cmb.SelectedValue as Model.Albums;
            VM.AlbumId = album.Id;
            await VM.LoadSongs();

            SongComboBox.SelectedItem = null;
            SongComboBox.Text = "";
        }
        private void SongComboBox_ValueChanged(object sender, Syncfusion.XForms.ComboBox.ValueChangedEventArgs e)
        {
            VM.NoResultsFoundText = "No results found, click here to add song " + e.Value;
            VM.SongName = e.Value;
        }

        private void SongComboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            SfComboBox cmb = sender as SfComboBox;

            Model.Songs song = cmb.SelectedValue as Model.Songs;
            VM.SongId = song.Id;
        }

        private void InsertTemplateButton_Clicked(object sender, EventArgs e)
        {
            var NotationType = VM.Notation.Type;
            if (NotationType == Model.NotationType.Tab)
            {
                NotationContent.Text = Properties.Resources.TabTemplate + NotationContent.Text;
            }
            if (NotationType == Model.NotationType.Chord)
            {
                NotationContent.Text = Properties.Resources.ChordTemplate + NotationContent.Text;
            }
        }
    }
}