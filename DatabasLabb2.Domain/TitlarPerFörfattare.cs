using System;
using System.Collections.Generic;

namespace DatabasLabb2.Domain;

public partial class TitlarPerFörfattare
{
    public string Namn { get; set; } = null!;

    public string Ålder { get; set; } = null!;

    public int? Titlar { get; set; }

    public string Lagervärde { get; set; } = null!;
}
