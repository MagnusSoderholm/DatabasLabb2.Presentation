using System;
using System.Collections.Generic;

namespace DatabasLabb2.Domain;

public partial class Leverantörer
{
    public int LeverantörsId { get; set; }

    public string Namn { get; set; } = null!;

    public string? Kontaktperson { get; set; }

    public string? Epostadress { get; set; }

    public string? Telefonnummer { get; set; }

    public string? Avtalsinformation { get; set; }

    public string? Adress { get; set; }

    public string? Postnummer { get; set; }

    public string? Stad { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
