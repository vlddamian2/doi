using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ChocoDemo.DataProvider.DBEngine;
using ChocoDemo.DataProvider.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ChocoDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            updateGrid();
        }

        private void addProductButtonClick(object sender, RoutedEventArgs e)
        {
            DBEngine.insertProduct(new Product()
                    {
                        ProductCode = this.productCodeTextBox.Text,
                        ProductDesription = this.productDescriptionTextBox.Text
                    });

            updateGrid();
        }

        private async void  updateGrid()
        {
            productsGrid.ItemsSource = await DBEngine.getAllProducts();
        }

        private async void searchTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            productsGrid.ItemsSource = 
                await DBEngine.filterProducts(searchTextBox.Text);
        }
    }
}
