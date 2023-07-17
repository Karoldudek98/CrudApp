using Microsoft.EntityFrameworkCore;
using System.Windows;
using CrudApp.Models;

namespace CrudApp
{
    public partial class AddEditProduktyWindow : Window
    {
        private Model _context;
        private Produkty _dataInstance;

        public Produkty NewProdukt { get; private set; }
        public AddEditProduktyWindow(Model context, Produkty dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new Produkty();

            DataContext = _dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_context.Entry(_dataInstance).State == EntityState.Detached)
            {
                _context.Produkty.Add(_dataInstance);
            }

            _context.SaveChanges();

            NewProdukt = _dataInstance;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
