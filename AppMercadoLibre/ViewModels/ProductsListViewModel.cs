using AppMercadoLibre.Models;
using AppMercadoLibre.Services;
using AppMercadoLibre.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMercadoLibre.ViewModels
{
    public class ProductsListViewModel : BaseViewModel
    {
        //Variables 
        static ProductsListViewModel instance;

        //Comandos
        private Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(RefreshProducts));

        private Command _SelectedCommand;
        public Command SelectedCommand => _SelectedCommand ?? (_SelectedCommand = new Command(SelectedAction));


        //Propiedades
        private List<ProductModel> _ListProducts;
        public List<ProductModel> ListProducts
        {
            get => _ListProducts;
            set => SetProperty(ref _ListProducts, value);
        }

        private ProductModel _SelectedProduct;
        public ProductModel SelectedProduct
        {
            get => _SelectedProduct;
            set => SetProperty(ref _SelectedProduct, value);
        }
        //Constructores
        public ProductsListViewModel()
        {
            instance = this;

            //Cargamos los productos
            LoadProducts();
        }

        //Métodos
        public static ProductsListViewModel GetInstance()
        {
            //rgeresamos la instancia de esta misma clase (this)
            return instance;
        }


        //Métodos
        private async void LoadProducts()
        {
            IsBusy = true;
            ListProducts = null;
            ApiResponse response = await new ApiService().GetDataAsync("Product");
            if (response == null || !response.IsSuccess)
            {
                //No hubo una respuesta exitosa
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("AppProducts", $"Error al cargar los productos: { response.Message}", " Ok");
                return;
            }
            ListProducts = JsonConvert.DeserializeObject<List<ProductModel>>(response.Result.ToString());
            IsBusy = false;
        }

        public void RefreshProducts()
        {
            LoadProducts();
        }

        private void NewAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProductsDetailPage());
        }

        private void SelectedAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ProductsDetailPage(SelectedProduct));
        }
    }
}
