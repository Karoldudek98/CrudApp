using CrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CrudApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Connection check
            using (var context = new Model())
            {
                try
                {
                    var result = context.Klienci.FirstOrDefault();

                    if (result != null)
                    {
                        MessageBox.Show("Database connection successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No data found in the table. Check your database or data model.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OpenDataManagementWindow_Click(object sender, RoutedEventArgs e)
        {
            var dataManagementWindow = new DataManagementWindow();
            dataManagementWindow.ShowDialog();

            dataManagementWindow.Closed += DataManagementWindow_Closed;
        }

        private void DataManagementWindow_Closed(object sender, System.EventArgs e)
        {
            DataContext = new Model();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
