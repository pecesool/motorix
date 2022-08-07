using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

namespace first.Views
{
    public partial class statistics : ContentPage
    {
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "1112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "428",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Forms",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            }
        };

        public statistics()
        {
            InitializeComponent();

            fff.Chart = new LineChart { Entries = entries, LineMode = LineMode.Straight, LabelTextSize = 30 };
            
        }
        protected override async void OnAppearing()
        {
            Coll.ItemsSource = await App.NotesDB.GetNotesAsync();
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            };
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            };
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "428",
                Color = SKColor.Parse("#b455b6")
            };
            new ChartEntry(514)
            {
                Label = "Forms",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            };
            base.OnAppearing();
        }
    }
    
}