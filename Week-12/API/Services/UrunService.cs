using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UrunService
    {
        private readonly MyDbContext _context;

        public UrunService(MyDbContext context)
        {
            _context = context;
        }

        public async Task UrunEkle(Urun yeniUrun)
        {
            _context.Uruns.Add(yeniUrun);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Urun>> UrunleriGetir()
        {
            return await _context.Uruns.ToListAsync();
        }

        public async Task<List<Kategori>> KategorileriGetir()
        {
            return await _context.Kategoris.ToListAsync();
        }

    }
}
