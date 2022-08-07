using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using first.data;
using SQLite;
using first.models;

namespace first.Views
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
                           
        }
        protected override void OnAppearing()
        {
            but1.Clicked += But1_Clicked;
            r1.Clicked += R1_Clicked;
            r2.Clicked += R2_Clicked;
            r3.Clicked += R3_Clicked;
            r4.Clicked += R4_Clicked;
            r5.Clicked += R5_Clicked;

            l1.Clicked += L1_Clicked;
            l2.Clicked += L2_Clicked;
            l3.Clicked += L3_Clicked;
            l4.Clicked += L4_Clicked;
            l5.Clicked += L5_Clicked;
            zav1.Clicked += Zav1_Clicked;
            zav.Clicked += Zav_Clicked;

        }

        private async void Zav_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Pal = "большой";
            note.Value = rr1;
            await App.NotesDB.Addsas(note);
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
        }

        private async void Zav1_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            note.Pal = "большой";
            note.Value = ll5;
            await App.NotesDB.Addsas(note);
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
        }

        int rr1 = 0;
        int rr2 = 0;
        int rr3 = 0;
        int rr4 = 0;
        int rr5 = 0;

        int ll1 = 0;
        int ll2 = 0;
        int ll3 = 0;
        int ll4 = 0;
        int ll5 = 0;
        private void L5_Clicked(object sender, EventArgs e)
        {

            ll5 = ll5 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(l55, Color.FromRgb(255, 255 - ll5, 255 - ll5));
        }

        private void L4_Clicked(object sender, EventArgs e)
        {
            ll4 = ll4 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(l44, Color.FromRgb(255, 255 - ll4, 255 - ll4));
        }

        private void L3_Clicked(object sender, EventArgs e)
        {
            ll3 = ll3 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(l33, Color.FromRgb(255, 255 - ll3, 255 - ll3));
        }

        private void L2_Clicked(object sender, EventArgs e)
        {
            ll2 = ll2 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(l22, Color.FromRgb(255, 255 - ll2, 255 - ll2));
        }

        private void L1_Clicked(object sender, EventArgs e)
        {
            ll1 = ll1 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(l11, Color.FromRgb(255, 255 - ll1, 255 - ll1));
        }

        private void R5_Clicked(object sender, EventArgs e)
        {
           rr5 = rr5 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r55, Color.FromRgb(255, 255 - rr5, 255 - rr5));
        }

        private void R4_Clicked(object sender, EventArgs e)
        {
            rr4 = rr4 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r44, Color.FromRgb(255, 255 - rr4, 255 - rr4));
        }

        private void R3_Clicked(object sender, EventArgs e)
        {
            rr3 = rr3 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r33, Color.FromRgb(255, 255 - rr3, 255 - rr3));
        }

        private void R2_Clicked(object sender, EventArgs e)
        {
            rr2 = rr2 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r22, Color.FromRgb(255, 255 - rr2, 255 - rr2));
        }

        private void R1_Clicked(object sender, EventArgs e)
        {
            rr1 = rr1 + 10;
            Xamarin.CommunityToolkit.Effects.IconTintColorEffect.SetTintColor(r11, Color.FromRgb(255, 255 - rr1, 255 - rr1));
        }

        private void But1_Clicked(object sender, EventArgs e)
        {
            con.IsVisible = false;
            choice.IsVisible = true;
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            con.IsVisible = false;
            choice.IsVisible = false;
            r.IsVisible = true;
            l.IsVisible = false;
            rr1 = 0;
           rr2 = 0;
            rr3 = 0;
            rr4 = 0;
            rr5 = 0;

            ll1 = 0;
            ll2 = 0;
            ll3 = 0;
            ll4 = 0;
            ll5 = 0;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            con.IsVisible = false;
            choice.IsVisible = false;
            r.IsVisible = false;
            l.IsVisible = true;

            rr1 = 0;
            rr2 = 0;
            rr3 = 0;
            rr4 = 0;
            rr5 = 0;

            ll1 = 0;
            ll2 = 0;
            ll3 = 0;
            ll4 = 0;
            ll5 = 0;
        }
    }
}
