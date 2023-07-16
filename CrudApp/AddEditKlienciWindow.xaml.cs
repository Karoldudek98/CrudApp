using Microsoft.EntityFrameworkCore;
using System.Windows;
using CrudApp.Models;

namespace CrudApp
{
    public partial class AddEditKlienciWindow : Window
    {
        private Model _context;
        private Klienci _dataInstance;

        public AddEditKlienciWindow(Model context, Klienci dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new Klienci();

            DataContext = _dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Entry(_dataInstance).State == EntityState.Detached)
            {
                _context.Klienci.Add(_dataInstance);
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

