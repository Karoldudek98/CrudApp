using CrudApp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

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

            Klienci = new ObservableCollection<Klienci>();
            Produkty = new ObservableCollection<Produkty>();
            SzczegolyZamowienia = new ObservableCollection<SzczegolyZamowienia>();
            Zamowienia = new ObservableCollection<Zamowienia>();

            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            Klienci.Clear();
            Produkty.Clear();
            SzczegolyZamowienia.Clear();
            Zamowienia.Clear();

            var klienci = _context.Klienci.ToList();
            var produkty = _context.Produkty.ToList();
            var szczegolyZamowienia = _context.SzczegolyZamowienia.ToList();
            var zamowienia = _context.Zamowienia.ToList();

            foreach (var klient in klienci)
            {
                Klienci.Add(klient);
            }

            foreach (var produkt in produkty)
            {
                Produkty.Add(produkt);
            }

            foreach (var szczegol in szczegolyZamowienia)
            {
                SzczegolyZamowienia.Add(szczegol);
            }

            foreach (var zamowienie in zamowienia)
            {
                Zamowienia.Add(zamowienie);
            }
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedItem == tabKlienci)
            {
                var addEditWindow = new AddEditKlienciWindow(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    Klienci.Add(addEditWindow.NewKlient);
                }
            }
            else if (tabControl.SelectedItem == tabProdukty)
            {
                var addEditWindow = new AddEditProduktyWindow(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
            {
                var addEditWindow = new AddEditSzczegolyZamowieniaWindow(_context, null);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabZamowienia)
            {
                var addEditWindow = new AddEditZamowieniaWindow(_context, null);
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
                var addEditWindow = new AddEditKlienciWindow(_context, SelectedItem as Klienci);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabProdukty)
            {
                var addEditWindow = new AddEditProduktyWindow(_context, SelectedItem as Produkty);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
            {
                var addEditWindow = new AddEditSzczegolyZamowieniaWindow(_context, SelectedItem as SzczegolyZamowienia);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else if (tabControl.SelectedItem == tabZamowienia)
            {
                var addEditWindow = new AddEditZamowieniaWindow(_context, SelectedItem as Zamowienia);
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

                try
                {
                    _context.SaveChanges();
                    Klienci.Remove(selectedKlient);
                    klienciListView.Items.Refresh();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    MessageBox.Show("The selected item could not be removed due to a concurrency issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (tabControl.SelectedItem == tabProdukty)
            {
                var selectedProdukt = SelectedItem as Produkty;
                _context.Produkty.Remove(selectedProdukt);

                try
                {
                    _context.SaveChanges();
                    Produkty.Remove(selectedProdukt);
                    produktyListView.Items.Refresh();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    MessageBox.Show("The selected item could not be removed due to a concurrency issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (tabControl.SelectedItem == tabSzczegolyZamowienia)
            {
                var selectedSzczegol = SelectedItem as SzczegolyZamowienia;
                _context.SzczegolyZamowienia.Remove(selectedSzczegol);

                try
                {
                    _context.SaveChanges();
                    SzczegolyZamowienia.Remove(selectedSzczegol);
                    szczegolyZamowieniaListView.Items.Refresh();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    MessageBox.Show("The selected item could not be removed due to a concurrency issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (tabControl.SelectedItem == tabZamowienia)
            {
                var selectedZamowienie = SelectedItem as Zamowienia;
                _context.Zamowienia.Remove(selectedZamowienie);

                try
                {
                    _context.SaveChanges();
                    Zamowienia.Remove(selectedZamowienie);
                    zamowieniaListView.Items.Refresh();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    MessageBox.Show("The selected item could not be removed due to a concurrency issue.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            LoadData();
        }
    }
}
