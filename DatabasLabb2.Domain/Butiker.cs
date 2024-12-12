using System;
using System.Collections.Generic;

namespace DatabasLabb2.Domain;

public partial class Butiker
{
    public int Id { get; set; }

    public string? Namn { get; set; }

    public string? Adress { get; set; }

    public string? Postnummer { get; set; }

    public string? Stad { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
