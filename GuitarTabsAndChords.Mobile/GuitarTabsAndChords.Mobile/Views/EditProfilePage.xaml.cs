using GuitarTabsAndChords.Mobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitarTabsAndChords.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        private readonly EditProfilePageViewModel VM;


        public EditProfilePage()
        {
            InitializeComponent();
            BindingContext = VM = new EditProfilePageViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await VM.Init();
        }

        //Picture choose from device    
        private async void BtnSelectPic_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.MaxWidthHeight
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;

                Stream stream1 = _mediaFile.GetStream();
                Stream stream2 = _mediaFile.GetStream();
                byte[] resizedImage1 = null;
                byte[] resizedImage2 = null;

                resizedImage1 = ResizeImage(stream1);
                resizedImage2 = ResizeImage(stream2);

                imageView.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage1));
                VM.User.ProfilePicture = resizedImage2;
            }
        }

        //Take picture from camera    
        private async void BtnTakePic_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":(No Camera available.)", "OK");
                return;
            }
            else
            {
                _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg",
                    PhotoSize = PhotoSize.MaxWidthHeight
                });

                if (_mediaFile == null) return;

                Stream stream1 = _mediaFile.GetStream();
                Stream stream2 = _mediaFile.GetStream();
                byte[] resizedImage1 = null;
                byte[] resizedImage2 = null;

                resizedImage1 = ResizeImage(stream1);
                resizedImage2 = ResizeImage(stream2);

                imageView.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage1));
                VM.User.ProfilePicture = resizedImage2;

            }
        }

        private MediaFile _mediaFile;
        private string URL { get; set; }


        public void Busy()
        {
            uploadIndicator.IsVisible = true;
            uploadIndicator.IsRunning = true;
            btnSelectPic.IsEnabled = false;
            btnTakePic.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        public void NotBusy()
        {
            uploadIndicator.IsVisible = false;
            uploadIndicator.IsRunning = false;
            btnSelectPic.IsEnabled = true;
            btnTakePic.IsEnabled = true;
            btnSave.IsEnabled = true;
        }


        protected byte[] ResizeImage(Stream stream)
        {
            byte[] resizedImage = null;
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                resizedImage = ms.ToArray();
            }

            //if (Device.RuntimePlatform == Device.Android)
            //    resizedImage = DependencyService.Get<IMediaService>().ResizeImage(resizedImage, 500, 500);

            return resizedImage;

        }
    }
}