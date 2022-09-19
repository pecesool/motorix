using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using first.ViewModel;
using Plugin.BluetoothClassic.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using first.data;
using first.models;
using SQLite;
using first.Views;



namespace first
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DigitPage : ContentPage
    {
        int thebigvall1 = 0;
        int thebigvall2 = 0;
        int thebigvall3 = 0;
        int thebigvall4 = 0;
        int thebigvall5 = 0;

        int thebigvalr1 = 0;
        int thebigvalr2 = 0;
        int thebigvalr3 = 0;
        int thebigvalr4 = 0;
        int thebigvalr5 = 0;


        public DigitPage()
        {
            InitializeComponent();
            DigitViewModel model = (DigitViewModel)BindingContext;
            
            

            if (App.CurrentBluetoothConnection != null)
            {
                App.CurrentBluetoothConnection.OnStateChanged += CurrentBluetoothConnection_OnStateChanged;
                App.CurrentBluetoothConnection.OnRecived += CurrentBluetoothConnection_OnRecived;
                
            }

        }

        

        protected override void OnAppearing()
        {
            zav.Clicked += Zav_Clicked;
            zav1.Clicked += Zav1_Clicked;
            rval1.BindingContextChanged += Rval1_BindingContextChanged;
        }

        private void Rval1_BindingContextChanged(object sender, EventArgs e)
        {
            int b = 0;
            davlenie = 0;
            b = Convert.ToInt32(rval1.Text);
            davlenie = b;
            davlenie = Convert.ToInt32(rval1.Text);
            if (davlenie > thebigvalr1) { thebigvalr1 = davlenie; };
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r11, Color.FromRgb(255, 255 - davlenie / 4, 255 - davlenie / 4));
        }

        private void Zav1_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Pal = "большой";
            note.Value = thebigvall5;
            App.NotesDB.Addsas(note);
            /*Note note1 = (Note)BindingContext;
            note1.Date = DateTime.UtcNow;
            note1.Pal = "указательный";
            note1.Value = ll4;
            await App.NoteDB.Addsas(note1);
            Note note2 = (Note)BindingContext;
            note2.Date = DateTime.UtcNow;
            note2.Pal = "средний";
            note2.Value = ll3;
            await App.NoteDB.Addsas(note2);
            Note note3 = (Note)BindingContext;
            note3.Date = DateTime.UtcNow;
            note3.Pal = "безымянный";
            note3.Value = ll2;
            await App.NoteDB.Addsas(note3);
            Note note4 = (Note)BindingContext;
            note4.Date = DateTime.UtcNow;
            note4.Pal = "мизинец";
            note4.Value = ll1;
            await App.NoteDB.Addsas(note4);*/
            Navigation.PushAsync(new MainPage());
            
        }

        private void Zav_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Pal = "большой";
            note.Value = thebigvalr1;
            App.NotesDB.Addsas(note);
            /* Note note1 = (Note)BindingContext;
             note1.Date = DateTime.UtcNow;
             note1.Pal = "указательный";
             note1.Value = rr2;
             await App.NoteDB.Addsas(note1);
             Note note2 = (Note)BindingContext;
             note2.Date = DateTime.UtcNow;
             note2.Pal = "средний";
             note2.Value = rr3;
             await App.NoteDB.Addsas(note2);
             Note note3 = (Note)BindingContext;
             note3.Date = DateTime.UtcNow;
             note3.Pal = "безымянный";
             note3.Value = rr4;
             await App.NoteDB.Addsas(note3);
             Note note4 = (Note)BindingContext;
             note4.Date = DateTime.UtcNow;
             note4.Pal = "мизинец";
             note4.Value = rr5;
             await App.NoteDB.Addsas(note4);*/
             Navigation.PushAsync(new MainPage());

        }

       

        ~DigitPage()
        {
            if (App.CurrentBluetoothConnection != null)
            {
                
                App.CurrentBluetoothConnection.OnRecived -= CurrentBluetoothConnection_OnRecived;
                App.CurrentBluetoothConnection.OnStateChanged -= CurrentBluetoothConnection_OnStateChanged;


            }
        }

        

        string ex = "0";
        int davlenie = 0;
        int b = 0;
        private void CurrentBluetoothConnection_OnRecived(object sender, RecivedEventArgs recivedEventArgs)
        {
            
            
            
            DigitViewModel model = (DigitViewModel)BindingContext;

            if (model != null)
            {
                model.SetReciving();

                  
                    
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //rval3.Text = System.Text.Encoding.UTF8.GetString(recivedEventArgs.Buffer.ToArray(), recivedEventArgs.Buffer.ToArray().Length, 0);
                        
                         if (r.IsVisible == true) 
                         { 
                            
                            ex= Encoding.UTF8.GetString(recivedEventArgs.Buffer.ToArray(), 0, recivedEventArgs.Buffer.ToArray().Length);
                         
                                rval1.Text= Encoding.UTF8.GetString(recivedEventArgs.Buffer.ToArray(), 0, recivedEventArgs.Buffer.ToArray().Length);
                                davlenie = Convert.ToInt32(rval1.Text);
                                if (davlenie > thebigvalr1) { thebigvalr1 = davlenie; };                                
                                Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r11, Color.FromRgb(255, 255 - davlenie/4, 255 - davlenie/4)); 
                         
                         /*if (b == 1) { b = 2; if (ex != "") { davlenie = Convert.ToInt32(ex); };
                                if (davlenie > thebigvalr2) { thebigvalr2 = davlenie; }; 
                                rval2.Text = davlenie.ToString(); 
                                Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r22, Color.FromRgb(255, 255 - davlenie / 4, 255 - davlenie / 4)); }
                         
                         if (b == 2) { b = 3; if (ex != "") { davlenie = Convert.ToInt32(ex); };
                                if (davlenie > thebigvalr3) { thebigvalr3 = davlenie; }; 
                                rval3.Text = davlenie.ToString(); 
                                Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r33, Color.FromRgb(255, 255 - davlenie / 4, 255 - davlenie / 4)); }
                         
                         if (b == 3) { b = 4; if (ex != "") { davlenie = Convert.ToInt32(ex); };
                                if (davlenie > thebigvalr4) { thebigvalr4 = davlenie; }; 
                                rval4.Text = davlenie.ToString(); 
                                Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r44, Color.FromRgb(255, 255 - davlenie / 4, 255 - davlenie / 4)); }
                         
                         if (b == 4) { b = 0; if (ex != "") { davlenie = Convert.ToInt32(ex); };
                                if (davlenie > thebigvalr5) { thebigvalr5 = davlenie; }; 
                                rval5.Text = davlenie.ToString(); 
                                Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r55, Color.FromRgb(255, 255 - davlenie / 4, 255 - davlenie / 4)); }*/
                         
                        
                         }
                    });
                         
                     
                
                model.SetRecived();
            }
        }

        private void CurrentBluetoothConnection_OnStateChanged(object sender, StateChangedEventArgs stateChangedEventArgs)
        {
            var model = (DigitViewModel)BindingContext;
            if (model != null)
            {
                model.ConnectionState = stateChangedEventArgs.ConnectionState;
            }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            r.IsVisible = false;
            l.IsVisible = true;
            choice.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            r.IsVisible = true;
            l.IsVisible = false;
            choice.IsVisible = false;
        }
    }
}