using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabasLabb2.Domain;

public partial class Författare
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string FullName => $"{Efternamn}, {Förnamn}";

    public DateTime? Födelsedatum { get; set; }

    public DateTime? Dödsdatum { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
