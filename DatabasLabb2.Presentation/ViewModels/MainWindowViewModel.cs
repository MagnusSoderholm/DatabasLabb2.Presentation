using DatabasLabb2.Domain;
using DatabasLabb2.Infrastructure.Data.Model;
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


                if (_selectedStore != null) // Kontrollera att en butik är vald
                {
                    LoadLagerSaldo();
                }

                //LoadLagerSaldo();

                RaisePropertyChanged();

                RaisePropertyChanged("LagerSaldos");
            }
        }

        public ObservableCollection<LagerSaldo> LagerSaldos { get; private set; }


        public MainWindowViewModel()
        {
            LoadStores();
           
        }

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
