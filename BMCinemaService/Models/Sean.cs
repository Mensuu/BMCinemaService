using System;
using System.Collections.Generic;

namespace BMCinemaService.Models;

public partial class Sean
{
    public int SeansId { get; set; }

    public TimeSpan Seans { get; set; }

    public virtual ICollection<BiletAl> BiletAls { get; } = new List<BiletAl>();
}
