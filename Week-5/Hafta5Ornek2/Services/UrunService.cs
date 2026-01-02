namespace Hafta5Ornek2.Services;
    using Hafta5Ornek2.Models;
using System.Security.Cryptography.X509Certificates;

public class UrunService
{
    public List<Urun> TumUrunler = new List<Urun> {

        new Urun() { urunId = 1,Baslik = "Peynir",STT = DateTime.Parse("14.10.2025"),Icındekıler = "sut,maya",adet=10},
        new Urun() { urunId = 2,Baslik = "süt",STT = DateTime.Parse("14.10.2025"),Icındekıler = "sut,kutu",adet = 15},
        new Urun() { urunId = 3,Baslik = "yumurta",STT = DateTime.Parse("14.10.2025"),Icındekıler = "yumurta,tavuk",adet = 21},
        new Urun() { urunId = 4,Baslik = "sucuk",STT = DateTime.Parse("14.10.2025"),Icındekıler = "dana,bağırsak",adet = 2 },
    };
    public List<Urun> Sepet = new List<Urun>();

    public void SepeteEkle(Urun urun)
    {
        Urun ekleUrun = new Urun()
        {
            urunId = urun.urunId,
            Baslik = urun.Baslik,
            STT = urun.STT,
            adet = 1
        };
        
        Sepet.Add(ekleUrun);
        urun.adet -= 1;
    }
    public void SepettenSil(Urun urun)
    {
        Urun bulunan = Sepet.FirstOrDefault(x => x.urunId == urun.urunId);
        if(bulunan != null) { 
            Sepet.Remove(bulunan);
            bulunan = TumUrunler.FirstOrDefault(x => x.urunId == urun.urunId);
            bulunan.adet += 1;
        }
    }
}
