﻿using CustomerErrand.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CustomerErrand.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListAllErrandsView : Page
    {
        public ListAllErrandsView()
        {
            this.InitializeComponent();
        }

        public string UpdateStatus()
        {
            string statusText = cmbUpdateStatus.SelectionBoxItem.ToString();
            return statusText;
        }

        private void btnShowActiveErrands_Click(object sender, RoutedEventArgs e)
        {
            lvShowErrands.ItemsSource = ErrandService.GetActiveErrands((Application.Current as App).connectionString);
        }

        private void btnShowClosedErrands_Click(object sender, RoutedEventArgs e)
        {
            lvShowErrands.ItemsSource = ErrandService.GetCompletedErrands((Application.Current as App).connectionString);
        }

        private void btnUpdateErrandStatus_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    ErrandService.UpdateErrandAsync(id, UpdateStatus()).GetAwaiter();
                
            //}
        }
    }
}
