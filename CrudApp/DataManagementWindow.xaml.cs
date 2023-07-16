using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CrudApp.Models;

namespace CrudApp
{
    public partial class DataManagementWindow : Window
    {
        private Model _context;

        public ObservableCollection<Klienci> Klienci { get; set; }
        public ObservableCollection<Produkty> Produkty { get; set; }
        public ObservableCollection<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
        public ObservableCollection<Zamowienia> Zamowienia { get; set; }
        public object SelectedItem { get; set; }

        public DataManagementWindow()
        {
            InitializeComponent();
            _context = new Model();

            LoadData();
            DataContext = this;
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
            if (tabControl.SelectedItem == tabKlienci)
            {
                var addEditWindow = new AddEditDataWindow<Klienci>(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabProdukty)
            {
                var addEditWindow = new AddEditDataWindow<Produkty>(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
            {
                var addEditWindow = new AddEditDataWindow<SzczegolyZamowienia>(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabZamowienia)
            {
                var addEditWindow = new AddEditDataWindow<Zamowienia>(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item to edit.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (tabControl.SelectedItem == tabKlienci)
            {
                var addEditWindow = new AddEditDataWindow<Klienci>(_context, SelectedItem as Klienci);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabProdukty)
            {
                var addEditWindow = new AddEditDataWindow<Produkty>(_context, SelectedItem as Produkty);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
            {
                var addEditWindow = new AddEditDataWindow<SzczegolyZamowienia>(_context, SelectedItem as SzczegolyZamowienia);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabZamowienia)
            {
                var addEditWindow = new AddEditDataWindow<Zamowienia>(_context, SelectedItem as Zamowienia);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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
            LoadData();
        }
    }
}
