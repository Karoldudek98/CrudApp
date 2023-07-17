using Microsoft.EntityFrameworkCore;
using System.Windows;
using CrudApp.Models;

namespace CrudApp
{
    public partial class AddEditProduktyWindow : Window
    {
        private Model _context;
        private Produkty _dataInstance;

        // AddEditProduktyWindow constructor
        public AddEditProduktyWindow(Model context, Produkty dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new Produkty();

            DataContext = _dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Check if the ID is 0 or not set
            if (_dataInstance.ID == 0)
            {
                _context.Produkty.Add(_dataInstance); // Use Add instead of Entry
            }

            _context.SaveChanges();

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
