using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BMCinemaService.Models;

public partial class BiletAl
{
    public int BiletAlId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public decimal Gsm { get; set; }

    public string Mail { get; set; } = null!;

    public int FilmId { get; set; }

    public DateTime Tarih { get; set; }

    public int SeansId { get; set; }

    [JsonIgnore]
    public virtual Film Film { get; set; } = null!;
    [JsonIgnore]
    public virtual Sean Seans { get; set; } = null!;
}
