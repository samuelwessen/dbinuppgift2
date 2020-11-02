using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class CreateNewerrandView : Page
    {
        public CreateNewerrandView()
        {
            this.InitializeComponent();
        }

        public string GetStatus()
        {
            string statusText = cmbStatus.SelectionBoxItem.ToString();
            return statusText;
        }

        public string GetCategory()
        {
            string categoryText = cmbCategory.SelectionBoxItem.ToString();
            return categoryText;
        }

        private async void btnCreateErrand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service.ErrandService.AddNewErrandAsync(tbDescription.Text, DateTime.Now, tbCustomerFullName.Text, tbCustomerEmail.Text, Convert.ToInt32(tbCustomerPhoneNr.Text), GetStatus(), GetCategory()).GetAwaiter(); 
            }
            catch
            {
                string message = "You must fill in all the required information like name, status and so on";
                MessageDialog msgdialog = new MessageDialog(message, "Error Message");
                await msgdialog.ShowAsync();
            }
        }
    }
}
