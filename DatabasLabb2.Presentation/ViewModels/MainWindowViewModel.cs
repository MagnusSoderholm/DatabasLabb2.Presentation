using DatabasLabb2.Domain;
using DatabasLabb2.Infrastructure.Data.Model;
using DatabasLabb2.Presentation.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace DatabasLabb2.Presentation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<LagerSaldo> LagerSaldos { get; private set; } = new ObservableCollection<LagerSaldo>();
        public DelegateCommand EditBookCommand { get; }
        public DelegateCommand DeleteBookCommand { get; }
        public DelegateCommand AddBookCommand { get; }
        public DelegateCommand AddBookToStoreCommand { get; }
        public DelegateCommand DeleteBookFromStoreCommand { get; }
        public DelegateCommand UpdateBookCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }
        public Action<object> EditBook { get; set; }
        public Action<object> DeleteBook { get; set; }
        public Action<object> AddBook { get; set; }
        public ObservableCollection<Butiker> Stores { get; private set; }
        public ObservableCollection<Böcker> Books { get; private set; } = new ObservableCollection<Böcker>();



        public MainWindowViewModel()
        {
            EditBookCommand = new DelegateCommand(DoEditBook, CanEditBook);
            DeleteBookCommand = new DelegateCommand(DoDeleteBook, CanDeleteBook);
            AddBookCommand = new DelegateCommand(DoAddBook);
            AddBookToStoreCommand = new DelegateCommand(AddBookToStore);
            DeleteBookFromStoreCommand = new DelegateCommand(DoDeleteBookFromStore);
            UpdateBookCommand = new DelegateCommand(UpdateBook);


            LoadBooks();
            LoadStores();
            

        }

        private void UpdateBook(object obj)
        {
            // DENNA KOD SKA SPARA ALLA UPPDATERINGAR MAN GÖR NÄR MAN REDIGERAR

            LoadLagerSaldo();

            if (obj is Window window)
            {

                window.Close();
            }
        }

        private Butiker? _selectedStore;
        public Butiker? SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;


                if (_selectedStore != null)
                {
                    LoadLagerSaldo();
                }


                RaisePropertyChanged();

                RaisePropertyChanged("LagerSaldos");
            }
        }



        private Böcker? _selectedBook;
        public Böcker? SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged();
            }
        }



        private string _lagerSaldo;
        public string LagerSaldo
        {
            get => _lagerSaldo;
            set
            {
                _lagerSaldo = value;
                RaisePropertyChanged();
            }
        }



        private LagerSaldo? _selectedRow;
        public LagerSaldo? SelectedRow
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
                RaisePropertyChanged();
                EditBookCommand?.RaiseCanExecuteChanged();
                DeleteBookCommand?.RaiseCanExecuteChanged();
                AddBookCommand?.RaiseCanExecuteChanged();
            }
        }


        private void DoDeleteBookFromStore(object obj)
        {
            if (SelectedStore == null || SelectedBook == null)
            {
                MessageBox.Show("Vänligen välj en butik och en bok att ta bort.");
                return;
            }

            using var db = new BokhandelContext();

            var existingLagerSaldo = db.LagerSaldos
                .FirstOrDefault(ls => ls.Isbn == SelectedBook.Isbn13 && ls.ButikId == SelectedStore.Id);

            if (existingLagerSaldo != null)
            {
                db.LagerSaldos.Remove(existingLagerSaldo);
                db.SaveChanges();
                MessageBox.Show("Boken har tagits bort från butiken.");


                LoadLagerSaldo();

                if (obj is Window window)
                {

                    window.Close();
                }
            }
            else
            {
                MessageBox.Show("Den här boken finns inte i den valda butiken.");
            }
        }



        private void AddBookToStore(object obj)
        {
            if (SelectedStore == null || SelectedBook == null || string.IsNullOrEmpty(LagerSaldo))
            {
                MessageBox.Show("Vänligen fyll i alla fält.");
                return;
            }

            if (!int.TryParse(LagerSaldo, out int antal))
            {
                MessageBox.Show("Lagersaldo måste vara ett giltigt heltal.");
                return;
            }

            using var db = new BokhandelContext();

            // Kontrollera om boken redan finns i butiken
            var existingEntry = db.LagerSaldos
                .FirstOrDefault(ls => ls.Isbn == SelectedBook.Isbn13 && ls.ButikId == SelectedStore.Id);

            if (existingEntry != null)
            {
                
                existingEntry.Antal += antal;
                db.SaveChanges();
                MessageBox.Show("Lagersaldo har uppdaterats.");
            }
            else
            {
                var newLagerSaldo = new LagerSaldo
                {
                    Isbn = SelectedBook.Isbn13,
                    ButikId = SelectedStore.Id,
                    Antal = antal
                };

                db.LagerSaldos.Add(newLagerSaldo);
                db.SaveChanges();
                MessageBox.Show("Boken har lagts till i butiken!");
            }

            LoadLagerSaldo();

            if (obj is Window window)
            {
                window.Close();
            }
        }



        private void LoadDistinctBooks()
        {
            using var db = new BokhandelContext();

            var distinctBooks = db.Böckers
                .GroupBy(b => b.Isbn13)
                .Select(g => g.FirstOrDefault())
                .ToList();

            Books.Clear();
            foreach (var book in distinctBooks)
            {
                Books.Add(book);
            }

            RaisePropertyChanged(nameof(Books));

        }

        private void DoAddBook(object obj) => AddBook(obj);
        private bool CanDeleteBook(object? arg) => SelectedRow is not null;
        private void DoDeleteBook(object obj) => DeleteBook(obj);
        private void DoEditBook(object obj) => EditBook(obj);
        private bool CanEditBook(object? arg) => SelectedRow is not null;


        private void LoadStores()
        {

            using var db = new BokhandelContext();

            Stores = new ObservableCollection<Butiker>(
                 db.Butikers.ToList()
                 );

            SelectedStore = Stores.FirstOrDefault();
        }


        public void LoadLagerSaldo()
        {
            using var db = new BokhandelContext();

            var lagerSaldoData = db.LagerSaldos
                .Where(l => l.ButikId == SelectedStore.Id)
                .Include(l => l.IsbnNavigation)
                .ThenInclude(l => l.Författare)
                .ToList();

           
            LagerSaldos.Clear();

            var distinctBooks = lagerSaldoData
                .GroupBy(l => l.Isbn)
                .Select(g => g.FirstOrDefault())
                .ToList();

            foreach (var item in distinctBooks)
            {
                LagerSaldos.Add(item);
            }

            RaisePropertyChanged(nameof(LagerSaldos));
        }



        private void LoadBooks()
        {
            using var db = new BokhandelContext();

            var allBooks = db.Böckers.ToList();

            Books.Clear();

            foreach (var book in allBooks
                .GroupBy(b => b.Isbn13)
                .Select(g => g.FirstOrDefault()))
            {
                Books.Add(book);
            }

            SelectedBook = Books.FirstOrDefault();
        }

    }
    
}

