using BlazorObs.Models;

// Bu servisi tüm bileşenler kullanacak
public class OgrenciService
{
    // Bak, bu liste artık static değil. 
    // Ama servisin kendisi "Singleton" olacağı için bu liste de tek olacak.
    private List<Ogrenci> ogrenciler = new List<Ogrenci>();

    public OgrenciService()
    {
        // Başlangıç verisi ekleyelim
        ogrenciler.Add(new Ogrenci { ogrenciNo = "100", adSoyad = "Ali Veli", bolum = "BM", vize = 80, final = 90 });
        ogrenciler.Add(new Ogrenci { ogrenciNo = "200", adSoyad = "Ayşe Kaya", bolum = "EE", vize = 70, final = 70 });
    }

    // Öğrencileri listeleyen metot
    public Task<List<Ogrenci>> GetOgrencilerAsync()
    {
        return Task.FromResult(ogrenciler);
    }

    // ID'ye (veya numaraya) göre öğrenci bulan metot
    public Task<Ogrenci> GetOgrenciByNoAsync(string no)
    {
        var ogrenci = ogrenciler.FirstOrDefault(o => o.ogrenciNo == no);
        return Task.FromResult(ogrenci);
    }

    // Yeni öğrenci ekleyen metot
    public Task AddOgrenciAsync(Ogrenci ogrenci)
    {
        // Ortalama hesaplamasını da servis yapsın, component değil
        ogrenci.ortalama = (ogrenci.vize * 0.4) + (ogrenci.final * 0.6);
        ogrenciler.Add(ogrenci);
        return Task.CompletedTask;
    }
}