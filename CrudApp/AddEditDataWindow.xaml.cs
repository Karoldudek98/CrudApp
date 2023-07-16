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
        private Model _context;
        private TEntity _dataInstance;

        public AddEditDataWindow(Model context, TEntity dataInstance)
        {
            //InitializeComponent(); // Ensure InitializeComponent is called in the constructor
            _context = context;
            _dataInstance = dataInstance;

            DataContext = _dataInstance; // Set the DataContext to the dataInstance
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
