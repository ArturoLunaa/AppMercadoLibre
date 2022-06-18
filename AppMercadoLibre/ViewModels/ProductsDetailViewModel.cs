using AppMercadoLibre.Models;
using AppMercadoLibre.Services;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppMercadoLibre.ViewModels
{
    public class ProductsDetailViewModel : BaseViewModel
    {
        //Variables locales

        public readonly ProductsListViewModel ListViewModel;

        //Comandos
        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        private Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        private Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));

        private Command _MapCommand;
        public Command MapCommand => _MapCommand ?? (_MapCommand = new Command(MapAction));

        //Propiedades
        private ProductModel _ProductSelected;
        public ProductModel ProductSelected
        {
            get => _ProductSelected;
            set => SetProperty(ref _ProductSelected, value);
        }

        private string _Picture;
        public string Picture
        {
            get => _Picture;
            set => SetProperty(ref _Picture, value);
        }

        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        //Constructores
        public ProductsDetailViewModel()
        {
            ProductSelected = new ProductModel();
        }

        public ProductsDetailViewModel(ProductModel productSelected)
        {
            //Producto existenete se carga
            ProductSelected = productSelected;
            Picture = productSelected.PictureImgBase64;
        }

        //Métodos

        private async void SaveAction()
        {
 
        }

        private async void DeleteAction()
        {

        }

        //Método implementado para tomar fotografía
        private async void TakePictureAction()
        {
            //Inicializa la cámara
            await CrossMedia.Current.Initialize();

            //Si no soporta la cámara o no está disponible lanza una excepción y termina el método
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            //Toma la fotografía y la regresa en el objeto file
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "AppMercadoLibre",
                Name = "cam_picture.jpg"
            });

            //Si el objeto es null termina el método (porque hubo un error o algo así)
            if (file == null)
                return;

            //Asignamos la ruta de la fotografía en la propiedad de la imagen
            Picture = ProductSelected.PictureImgBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);//file.Path;


        }

        //Método implementado para seleccionar fotografía
        private async void SelectPictureAction()
        {
            //Inicializa la cámara
            await CrossMedia.Current.Initialize();

            //Si seleccionar fotografía o no está disponible lanza una excepción y termina el método
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Couldn't pick a photo", ":( No photo available.", "OK");
                return;
            }

            //Selecciona la fotografía del carrete y la regresa en el objeto file
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            //Si el objeto es null termina el método (porque hubo un error o algo así)
            if (file == null)
                return;

            //Asignamos la ruta de la fotografía en la propiedad de la imagen
            Picture = ProductSelected.PictureImgBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);//file.Path;
        }

        private async void GetLocationAction()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private void MapAction(object obj)
        {


        }
    }
}
