using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DatabasLabb2.Domain;

public partial class LagerSaldo
{
    //public int ButikId { get; set; }

    //public string Isbn { get; set; } = null!;

    //public int? Antal { get; set; }

    //public virtual Butiker Butik { get; set; } = null!;

    //public virtual Böcker IsbnNavigation { get; set; } = null!;
    //public string SaldoText => Antal == 0 ?  " <Slut i lager> " : Antal.ToString();

 
    
        private int? _antal;

        public int ButikId { get; set; }

        public string Isbn { get; set; } = null!;


        public int? Antal
        {
            get => _antal;
            set
            {
                if (_antal != value)
                {
                    _antal = value;
               
                RaisePropertyChanged(nameof(Antal));
                    RaisePropertyChanged(nameof(SaldoText));
                }
            }
        }

        public virtual Butiker Butik { get; set; } = null!;

        public virtual Böcker IsbnNavigation { get; set; } = null!;


        public string SaldoText => Antal == 0 ? "<Slut i lager>" : Antal.ToString();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
}
