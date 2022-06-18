using AppMercadoLibre.Models;
using AppMercadoLibre.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMercadoLibre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsDetailPage : ContentPage
    {
        public ProductsDetailPage()
        {
            InitializeComponent();

            BindingContext = new ProductsDetailViewModel();
        }

        public ProductsDetailPage(ProductModel productSelected)
        {
            InitializeComponent();

            BindingContext = new ProductsDetailViewModel(productSelected);
        }
    }
}