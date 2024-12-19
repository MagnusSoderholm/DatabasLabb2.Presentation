using System;
using System.Collections.Generic;

namespace DatabasLabb2.Domain;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string? Titel { get; set; }

    public string? Språk { get; set; }

    public decimal? Pris { get; set; }

    public string TitelList => $"{Titel} ({Format})";

    public DateOnly? Utgivningsdatum { get; set; }

    public int? FörfattareId { get; set; }

    public string? Genre { get; set; }

    public int? Sidor { get; set; }

    public string? Format { get; set; }

    public int? FörlagsId { get; set; }

    public int? LeverantörsId { get; set; }

    public virtual Författare? Författare { get; set; }

    public virtual Förlag? Förlags { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();

    public virtual Leverantörer? Leverantörs { get; set; }
}
