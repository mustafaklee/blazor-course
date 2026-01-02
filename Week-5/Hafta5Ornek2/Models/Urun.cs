using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualBasic;

namespace Hafta5Ornek2.Models
{
    public class Urun
    {
        public int urunId { get; set; }
        public string Baslik { get; set;}

        public string Icındekıler {  get; set; }    

        public DateTime STT { get; set; }   

        public int adet {  get; set; }  

        
    }
}
