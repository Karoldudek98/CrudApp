using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApp
{
    public partial class DataManagementWindow : Window, INotifyPropertyChanged
    {
        private Model _context;
        private object _selectedItem;

        public ObservableCollection<Klienci> Klienci { get; set; }
        public ObservableCollection<Produkty> Produkty { get; set; }
        public ObservableCollection<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
        public ObservableCollection<Zamowienia> Zamowienia { get; set; }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public DataManagementWindow()
        {
            InitializeComponent();
            _context = new Model();

            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            Klienci = new ObservableCollection<Klienci>(_context.Klienci.ToList());
            Produkty = new ObservableCollection<Produkty>(_context.Produkty.ToList());
            SzczegolyZamowienia = new ObservableCollection<SzczegolyZamowienia>(_context.SzczegolyZamowienia.ToList());
            Zamowienia = new ObservableCollection<Zamowienia>(_context.Zamowienia.ToList());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                if (tabControl.SelectedItem == tabKlienci)
                {
                    var selectedKlient = SelectedItem as Klienci;
                    _context.Klienci.Remove(selectedKlient);
                }
                else if (tabControl.SelectedItem == tabProdukty)
                {
                    var selectedProdukt = SelectedItem as Produkty;
                    _context.Produkty.Remove(selectedProdukt);
                }
                else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
                {
                    var selectedSzczegol = SelectedItem as SzczegolyZamowienia;
                    _context.SzczegolyZamowienia.Remove(selectedSzczegol);
                }
                else if (tabControl.SelectedItem == tabZamowienia)
                {
                    var selectedZamowienie = SelectedItem as Zamowienia;
                    _context.Zamowienia.Remove(selectedZamowienie);
                }

                _context.SaveChanges();
                Klienci.Remove(SelectedItem as Klienci);
                Produkty.Remove(SelectedItem as Produkty);
                SzczegolyZamowienia.Remove(SelectedItem as SzczegolyZamowienia);
                Zamowienia.Remove(SelectedItem as Zamowienia);
                SelectedItem = null;
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("Issue with removing data", "Concurrency Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
