using Microsoft.EntityFrameworkCore;
namespace Week11.Models
{
    public class DepoDbContext : DbContext
    {
        public DepoDbContext(DbContextOptions<DepoDbContext> option) : base(option)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Personel> Personeller { get; set; }


        public void UrunEkle()
        {
            Urun urun = new Urun();
            Urunler.Add(urun);
            SaveChanges();
        }

        public List<Urun> UrunleriGetir()
        {
            return Urunler.ToList();
        }


        public Urun UrunGetir(int id)
        {
            return Urunler.First(u => u.Id == id);
        }


    }
}
