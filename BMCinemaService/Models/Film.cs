using System;
using System.Collections.Generic;

namespace BMCinemaService.Models;

public partial class Film
{
    public int FilmId { get; set; }

    public string Film1 { get; set; } = null!;

    public virtual ICollection<BiletAl> BiletAls { get; } = new List<BiletAl>();
}
