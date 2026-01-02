using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UrunKategori
{
    public int UrunKategoriId { get; set; }

    public int UrunId { get; set; }

    public int KategoriId { get; set; }
}
