using CrudApp.Models;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CrudApp
{
    public partial class AddEditZamowieniaWindow : Window
    {
        private Model _context;
        private Zamowienia _dataInstance;

        public AddEditZamowieniaWindow(Model context, Zamowienia dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new Zamowienia();

            DataContext = new { DataInstance = _dataInstance, IsNew = dataInstance == null };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _context.Entry(_dataInstance).State = _dataInstance.ID > 0 ? EntityState.Modified : EntityState.Added;
            _context.SaveChanges();

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
