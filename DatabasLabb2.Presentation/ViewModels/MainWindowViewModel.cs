using DatabasLabb2.Domain;
using DatabasLabb2.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasLabb2.Presentation.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<string> Butiker { get; private set; }

        private string? _selectedButiker;

        public string? SelectedButiker
        {
            get => _selectedButiker;
            set
            {
                _selectedButiker = value;
                RaisePropertyChanged();
                LoadButikerDetails();
                RaisePropertyChanged("ButikerDetails");
            }
        }

        public ObservableCollection<Butiker> ButikerDetails { get; private set; }



        public MainWindowViewModel()
        {
            LoadButiker();
           
        }

        private void LoadButiker()
        {
            using var db = new BokhandelContext();

            Butiker = new ObservableCollection<string>(
                db.Butikers.Select(b => b.Namn).Distinct().ToList()
                );

            SelectedButiker = Butiker.FirstOrDefault();
        }


        private void LoadButikerDetails()
        {
            using var db = new BokhandelContext();

            ButikerDetails = new ObservableCollection<Butiker>(
                db.Butikers.Where(b => b.Namn == SelectedButiker).ToList()
                );

           
        }
    }
}
