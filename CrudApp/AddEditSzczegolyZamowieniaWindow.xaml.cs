using CrudApp.Models;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CrudApp
{
    public partial class AddEditSzczegolyZamowieniaWindow : Window
    {
        private Model _context;
        private SzczegolyZamowienia _dataInstance;

        public SzczegolyZamowienia NewSzczegol { get; private set; }

        public AddEditSzczegolyZamowieniaWindow(Model context, SzczegolyZamowienia dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new SzczegolyZamowienia();

            DataContext = _dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Entry(_dataInstance).State == EntityState.Detached)
            {
                _context.SzczegolyZamowienia.Add(_dataInstance);
            }

            _context.SaveChanges();

            NewSzczegol = _dataInstance;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
