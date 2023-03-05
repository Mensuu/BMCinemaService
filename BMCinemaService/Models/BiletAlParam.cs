using System;
using System.Collections.Generic;

namespace BMCinemaService.Models;

public partial class BiletAlParam
{
    public int BiletAlId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public decimal Gsm { get; set; }

    public string Mail { get; set; } = null!;

    public int Film { get; set; }

    public DateTime Tarih { get; set; }

    public int Seans { get; set; }

}
