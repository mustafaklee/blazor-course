using System;
using System.Collections.Generic;

namespace OrtakKullanım;

public partial class Urun
{
    public int UrunId { get; set; }

    public string Baslik { get; set; } = null!;

    public decimal Fiyat { get; set; }

    public int? Adet { get; set; }
}
