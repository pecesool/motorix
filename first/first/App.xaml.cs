using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using first.data;
using System.IO;
using Plugin.BluetoothClassic.Abstractions;

namespace first
{
    public partial class App : Application
    {
        static NotesDB notesDB;
        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null) { notesDB = new NotesDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3")); }
            
            return notesDB;
            }
        }
        public static IBluetoothManagedConnection CurrentBluetoothConnection { get; internal set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
