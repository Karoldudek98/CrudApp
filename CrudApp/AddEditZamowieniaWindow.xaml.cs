using CrudApp.Models;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using CrudApp.Models;
using System.Windows;
using System;

namespace CrudApp
{
    public partial class AddEditZamowieniaWindow : Window
    {
        private Model _context;
        private Zamowienia _dataInstance;

        public Zamowienia NewZamowienie { get; private set; }

        public AddEditZamowieniaWindow(Model context, Zamowienia dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new Zamowienia();

            DataContext = _dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_dataInstance.ID == 0)
            {
                MessageBox.Show("Please set a valid ID for the Zamowienia item.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingEntity = _context.Zamowienia.Find(_dataInstance.ID);
            if (existingEntity == null)
            {
                _context.Zamowienia.Add(_dataInstance);
            }
            else
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(_dataInstance);
            }

            try
            {
                _context.SaveChanges();

                NewZamowienie = _dataInstance;

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the changes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
