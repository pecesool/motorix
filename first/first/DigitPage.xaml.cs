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

        DigitViewModel model;
        public DigitPage()
        {
            InitializeComponent();
            
            model = (DigitViewModel)BindingContext;

            BindingContext = new Note();
            
            
            

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

        private async void Zav1_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Pal = "большой";
            note.Value = thebigvall5;
            await App.NotesDB.Addsas(note);
            Note note1 = (Note)BindingContext;
            note1.Date = DateTime.UtcNow;
            note1.Pal = "указательный";
            note1.Value = thebigvall4;
            await App.NotesDB.Addsas(note1);
            Note note2 = (Note)BindingContext;
            note2.Date = DateTime.UtcNow;
            note2.Pal = "средний";
            note2.Value = thebigvall3;
            await App.NotesDB.Addsas(note2);
            Note note3 = (Note)BindingContext;
            note3.Date = DateTime.UtcNow;
            note3.Pal = "безымянный";
            note3.Value = thebigvall2;
            await App.NotesDB.Addsas(note3);
            Note note4 = (Note)BindingContext;
            note4.Date = DateTime.UtcNow;
            note4.Pal = "мизинец";
            note4.Value = thebigvall1;
            await App.NotesDB.Addsas(note4);

            await Navigation.PushAsync(new MainPage());
            
        }

        private async void Zav_Clicked(object sender, EventArgs e)
        {
            
                    Note note = (Note)BindingContext;
                    note.Date = DateTime.UtcNow;
                    note.Pal = "большой палец";
                    note.Ruka = "Правая рука";
                    note.Value = thebigvalr1;
                    await App.NotesDB.Addsas(note);
                    BindingContext = new Note(); 
            
                 Note note1 = (Note)BindingContext;
                 note1.Date = DateTime.UtcNow;
                    note1.Ruka = "Правая рука";
                    note1.Pal = "Указательный палец";
                 note1.Value = thebigvalr2;
                 await App.NotesDB.Addsas(note1);
            BindingContext = new Note();

            Note note2 = (Note)BindingContext;
                 note2.Date = DateTime.UtcNow;
                    note2.Ruka = "Правая рука";
                    note2.Pal = "Средний палец";
                 note2.Value = thebigvalr3;
                 await App.NotesDB.Addsas(note2);
            BindingContext = new Note();

            Note note3 = (Note)BindingContext;
                 note3.Date = DateTime.UtcNow;
                    note3.Ruka = "Правая рука";
                    note3.Pal = "Безымянный палец";
                 note3.Value = thebigvalr4;
                 await App.NotesDB.Addsas(note3);
            BindingContext = new Note();

            Note note4 = (Note)BindingContext;
                 note4.Date = DateTime.UtcNow;
                    note4.Ruka = "Правая рука";
                    note4.Pal = "Мизинец";
                 note4.Value = thebigvalr5;
                 await App.NotesDB.Addsas(note4);
            BindingContext = new Note();

            await Shell.Current.GoToAsync(".."); 

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
        int davl1 = 0;
        int davl2 = 0;
        int davl3 = 0;
        int davl4 = 0;
        int davl5 = 0;
        int b = 0;
        bool input1;
        bool input2;
        bool input3;
        bool input4;
        bool input5;

        private void CurrentBluetoothConnection_OnRecived(object sender, RecivedEventArgs recivedEventArgs)
        {
            
            
            
            

            if (model != null)
            {
                model.SetReciving();

                  
                    
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //rval3.Text = System.Text.Encoding.UTF8.GetString(recivedEventArgs.Buffer.ToArray(), recivedEventArgs.Buffer.ToArray().Length, 0);
                        
                         if (r.IsVisible == true) 
                         {
                            
                            
                         
                                ex= Encoding.UTF8.GetString(recivedEventArgs.Buffer.ToArray(), 0, recivedEventArgs.Buffer.ToArray().Length);
                                ex.ToString();
                                char firstval = ex[ex.Length-1];
                                string result = ex.Remove(ex.Length - 1);
                                if (int.TryParse(result, out davlenie))
                                

                                if (firstval == '1') 
                                {
                                    input1 = true; 
                                    davl1 = davlenie;
                                    
                                }

                                if (firstval == '2') 
                                {   
                                    input2= true;
                                    davl2 = davlenie;
                                    
                            
                                }

                                if (firstval == '3')
                                {
                                    input3= true;
                                    davl3= davlenie;
                                    

                                }

                                if (firstval == '4')
                                { 
                                    input4= true;
                                    davl4 = davlenie;
                                    

                                }

                                if (firstval == '5')
                                {
                                    input5= true;
                                    davl5 = davlenie;                                   

                                }
                            
                                if(input1==true && input2==true && input3==true && input4==true && input5 == true)
                                {
                                    rval1.Text = davl1.ToString();
                                    if (davl1 > thebigvalr1) { thebigvalr1 = davl1; };
                                    Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r11, Color.FromRgb(255, 255 - davl1 / 4, 255 - davl1 / 4));

                                    rval2.Text = davl2.ToString();
                                    if (davl2 > thebigvalr2) { thebigvalr2 = davl2; };
                                    Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r22, Color.FromRgb(255, 255 - davl2 / 4, 255 - davl2 / 4));

                                    rval3.Text = davl3.ToString();
                                    if (davl3 > thebigvalr3) { thebigvalr3 = davl3; };
                                    Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r33, Color.FromRgb(255, 255 - davl3 / 4, 255 - davl3 / 4));

                                    rval4.Text = davl4.ToString();
                                    if (davl4 > thebigvalr4) { thebigvalr4 = davl4; };
                                    Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r44, Color.FromRgb(255, 255 - davl4 / 4, 255 - davl4 / 4));

                                    rval5.Text = davl5.ToString();
                                    if (davl5 > thebigvalr5) { thebigvalr5 = davl5; };
                                    Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r55, Color.FromRgb(255, 255 - davl5 / 4, 255 - davl5 / 4));

                                    input1 = false;
                                    input2 = false;
                                    input3 = false;
                                    input4 = false;
                                    input5 = false;

                                } 
                                  
                            

                                                 
                                                                
                        }
                    });
                         
                     
                
                model.SetRecived();
            }
        }

        private void CurrentBluetoothConnection_OnStateChanged(object sender, StateChangedEventArgs stateChangedEventArgs)
        {
            
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