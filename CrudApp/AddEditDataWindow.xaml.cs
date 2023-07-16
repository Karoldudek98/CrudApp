using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CrudApp.Models;
using Microsoft.EntityFrameworkCore;


namespace CrudApp
{

    public partial class AddEditDataWindow<TEntity> : Window
    {
        private void InitializeComponent()
        {
            System.Uri resourceLocater = new System.Uri("/CrudApp;component/AddEditDataWindow.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }

        private Model _context;
        private TEntity _dataInstance;

        public AddEditDataWindow(Model context, TEntity dataInstance)
        {
            InitializeComponent();
            _context = context;
            _dataInstance = dataInstance;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _context.Entry(_dataInstance).State = _context.Entry(_dataInstance).IsKeySet ? EntityState.Modified : EntityState.Added;
            _context.SaveChanges();

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
