namespace Week11.Models
{
    public class VeriTabanıServis
    {
        public readonly DepoDbContext _context;
        public VeriTabanıServis(DepoDbContext context)
        {
            _context = context;   
        }

        public List<Urun> UrunleriGetir()
        {
            return _context.UrunleriGetir();
        }

    }
}
