using System;
using System.Collections.Generic;

namespace BMCinemaService.Models;

public partial class VbiletAl
{
    public int BiletAlId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public decimal Telefon { get; set; }

    public string Mail { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public TimeSpan Seans { get; set; }

    public string Film { get; set; } = null!;
}
