using System.Collections.Generic;

namespace EF.Models
{
    class Fatura
    {
        public long Id { get; set; }
        public ICollection<Ligacao> Ligacoes { get; set; }
    }
}
