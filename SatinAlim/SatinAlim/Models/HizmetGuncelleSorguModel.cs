using Microsoft.EntityFrameworkCore.Query;

namespace SatinAlim.Models
{
        public class HizmetGuncelleSorguModel
        {
            public int SatinAlmaHizmetKod { get; set; }
            public string? Tanim { get; set; }
            public string? Aciklama { get; set; }
            public string? Birim { get; set; }


        }
}
