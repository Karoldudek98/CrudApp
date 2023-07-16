using Microsoft.EntityFrameworkCore;
using System.Windows;
using CrudApp.Models;

namespace CrudApp
{
    public partial class AddEditKlienciWindow : Window
    {
        private Model _context;
        private Klienci _dataInstance;

        public Klienci NewKlient { get; private set; } // Property to expose the newly added Klient

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

            // Expose the newly added Klient through the NewKlient property
            NewKlient = _dataInstance;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
