using CrudApp.Models;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CrudApp
{
    public partial class AddEditSzczegolyZamowieniaWindow : Window
    {
        private Model _context;
        private SzczegolyZamowienia _dataInstance;

        public AddEditSzczegolyZamowieniaWindow(Model context, SzczegolyZamowienia dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance ?? new SzczegolyZamowienia();

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
