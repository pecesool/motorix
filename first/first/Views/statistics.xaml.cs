using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using first.ViewModel;
using Plugin.BluetoothClassic.Abstractions;
using first.data;
using first.models;
using SQLite;
using first.Views;

namespace first.Views
{
    public partial class statistics : ContentPage
    {
        public ChartEntry[] entries;

        public statistics()
        {
            InitializeComponent();

            
            
        }
        protected override async void OnAppearing()
        {
            Coll.ItemsSource = await App.NotesDB.GetNotesAsync();
           
            
            

            base.OnAppearing();
            push.Clicked += Push_Clicked;
        }

        private async void Push_Clicked(object sender, EventArgs e)
        {
            /*for (int i = 0; i < 10; i++)
            {
                Note note = await App.NotesDB.GetNoteAsync(i);
                entries = new[]
                {
                    new ChartEntry(i)
                    {
                    Label = "aa",
                    ValueLabel = "10",
                    Color = SKColor.Parse("#3498db")
                    }
                };
                fff.Chart = new LineChart { Entries = entries, LineMode = LineMode.Straight, LabelTextSize = 30 };
            }*/
            
        }
    }
    
}