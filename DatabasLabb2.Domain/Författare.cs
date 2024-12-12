using System;
using System.Collections.Generic;

namespace DatabasLabb2.Domain;

public partial class Författare
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public DateTime? Födelsedatum { get; set; }

    public DateTime? Dödsdatum { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
