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
using Coding4Fun.Toolkit.Controls;
using DayCounter.ViewModel;
using System.IO.IsolatedStorage;
using System.ComponentModel;

namespace DayCounter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            check();
            lb.ItemsSource = App.ViewModel.MyCounter.Items;
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Terminate();
        }

         //sample code for building a localized applicationbar
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();
           
            ApplicationBarIconButton addAppBar= 
                new ApplicationBarIconButton();

            addAppBar.IconUri = new Uri("/Assets/AppBar/add.png", UriKind.Relative);
            addAppBar.Text = AppResources.AppBarAdd;

            addAppBar.Click += addAppBar_Click;

            ApplicationBarMenuItem aboutAppBar = new ApplicationBarMenuItem();
            aboutAppBar.Text = AppResources.AppBarAbout;

            aboutAppBar.Click += aboutAppBar_Click;

            ApplicationBar.Buttons.Add(addAppBar);
            ApplicationBar.MenuItems.Add(aboutAppBar);
        }

        void aboutAppBar_Click(object sender, EventArgs e)
        {
            AboutPrompt aboutMe = new AboutPrompt();
            aboutMe.Title = "DayCounter";
            aboutMe.VersionNumber = "Version 1.0";
            AboutPromptItem item1 = new AboutPromptItem();
            AboutPromptItem item2 = new AboutPromptItem();
            AboutPromptItem item3 = new AboutPromptItem();

            item1.AuthorName = "Yk Poh";
            item2.EmailAddress = @"ykpoh@outlook.com";
            item3.WebSiteUrl = "@yk_poh";
            item1.Role = "author";
            item2.Role = "email";
            item3.Role = "twitter";
            aboutMe.Show(item1,item2,item3);
        }
        void addAppBar_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EditAndUpdate.xaml", UriKind.RelativeOrAbsolute));
        }

        private void check()
        {

            var test = App.ViewModel.MyCounter.Items;
            //App.ViewModel.MyCounter.Items.Clear();

            foreach (var item in test)
            {
                CounterData nnn = new CounterData
                {
                    Days = recheckdays(item.Date),
                    Date = item.Date,
                    Title = item.Title,
                    FilePath = item.FilePath,
                    DisplayDate = item.DisplayDate,
                    Description = item.Description
                };

                App.ViewModel.MyCounter.Items = (from L1 in App.ViewModel.MyCounter.Items
                                                 where L1.Title != item.Title
                                                 select L1).ToList();
                
                
                App.ViewModel.MyCounter.Items.Add(nnn);
            }




            lb.ItemsSource = App.ViewModel.MyCounter.Items;
        }

        private string recheckdays(DateTime thedt)
        {
            string result = "";
            CounterData mmm = new CounterData
            {
                OriginalDays = thedt.Subtract(DateTime.Now),
            };
            mmm.Days = mmm.OriginalDays.TotalDays.ToString("#0");
            result = mmm.Days;
            

            return result;
        }

        private void Grid_Holding(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

    }
}