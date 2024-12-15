using DatabasLabb2.Domain;
using DatabasLabb2.Infrastructure.Data.Model;
using DatabasLabb2.Presentation.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace DatabasLabb2.Presentation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Butiker> Stores { get; private set; }

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
            }
        }


        public ObservableCollection<LagerSaldo> LagerSaldos { get; private set; }
        public DelegateCommand EditBookCommand { get; }
        public DelegateCommand DeleteBookCommand { get; }
        public Action<object> EditBook { get; set; }

        public Action<object> DeleteBook { get; set; }

        public MainWindowViewModel()
        {

            EditBookCommand = new DelegateCommand(DoEditBook, CanEditBook);
            DeleteBookCommand = new DelegateCommand(DoDeleteBook, CanDeleteBook);

            LoadStores();


           
        }

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


        private void LoadLagerSaldo()
        {
            using var db = new BokhandelContext();

            LagerSaldos = new ObservableCollection<LagerSaldo>(
                db.LagerSaldos
                .Where(l => l.ButikId == SelectedStore.Id)
                .Include(l => l.IsbnNavigation)
                .ThenInclude(l => l.Författare)
                .ToList()
                );


        }
    }
}
