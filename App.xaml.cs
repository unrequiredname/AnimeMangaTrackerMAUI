using System;
using System.IO;
using AnimeMangaTrackerMAUI.Data;

namespace AnimeMangaTrackerMAUI;

    public partial class App : Application
        {
        static TrackingListDatabase database;

        public static TrackingListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TrackingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TrackingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
