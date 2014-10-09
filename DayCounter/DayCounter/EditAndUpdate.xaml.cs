using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DayCounter.Resources;
using DayCounter.ViewModel;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;
using Coding4Fun.Toolkit.Controls;

namespace DayCounter
{
    public partial class EditAndUpdate : PhoneApplicationPage
    {
        //private IsolatedStorageFileStream _counterStream;
        //private string _tempFileName = "tempCounter.txt";
        public EditAndUpdate()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        //sample code for building a localized applicationbar
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton saveAppBar =
                new ApplicationBarIconButton();

            saveAppBar.IconUri = new Uri("/Assets/AppBar/save.png", UriKind.Relative);
            saveAppBar.Text = AppResources.AppBarSave;

            saveAppBar.Click += saveAppBar_Click;

            ApplicationBarIconButton cancelAppBar = new ApplicationBarIconButton();
            cancelAppBar.IconUri = new Uri("/Assets/AppBar/cancel.png", UriKind.Relative);
            cancelAppBar.Text = AppResources.AppBarCancel;

            cancelAppBar.Click += cancelAppBar_Click;

            ApplicationBar.Buttons.Add(saveAppBar);
            ApplicationBar.Buttons.Add(cancelAppBar);
        }

        private void cancelAppBar_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void saveAppBar_Click(object sender, EventArgs e)
        {
            if (UserEvent.Text == null)
                throw new ArgumentNullException("Attempting to save an empty event's name");

            if (UserDate.Value.HasValue)
            {
                if (UserDate.Value.Value > DateTime.Now)
                {
                    CounterData counterdata = new CounterData();
                    counterdata.FilePath = string.Format("/MyCounter/{0}.txt", UserEvent.Text);
                    counterdata.Title = UserEvent.Text;
                    counterdata.Description = UserDescription.Text;
                    counterdata.Date = UserDate.Value.Value;
                    counterdata.DisplayDate = counterdata.Date.ToString("MM/dd/yyyy");
                    TimeSpan d = UserDate.Value.Value.Subtract(DateTime.Now);
                    counterdata.OriginalDays = d;
                    counterdata.Days = d.TotalDays.ToString("##");
                    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (!isoStore.DirectoryExists("/MyCounter/"))
                            isoStore.CreateDirectory("/MyCounter/");

                    }
                    App.ViewModel.MyCounter.Items.Add(counterdata);

                    var data = JsonConvert.SerializeObject(App.ViewModel.MyCounter);

                    IsolatedStorageSettings.ApplicationSettings[CounterModel.CustomCounterKey] = data;
                    IsolatedStorageSettings.ApplicationSettings.Save();

                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                }
            }
            NavigationService.Navigate(new Uri("/EditAndUpdate.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}