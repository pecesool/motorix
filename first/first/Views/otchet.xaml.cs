using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using first.data;
using first.models;
using SQLite;
using first.Views;
using Xamarin.Forms;


namespace first.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class otchet : ContentPage
    {
        public otchet()
        {
            InitializeComponent();
            BindingContext = new Note();
        }
        protected override void OnAppearing()
        {
           
        }

    }
}