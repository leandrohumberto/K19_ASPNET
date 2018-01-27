using System;

namespace EF.Models
{
    class Despesa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }
        public DateTime? Data { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            var cultureInfo = System.Globalization.CultureInfo.CurrentUICulture;
            return $"{Nome} - {Valor?.ToString("c", cultureInfo) ?? "[Sem valor]"} - {Tipo} - {Data?.ToString("d", cultureInfo) ?? "[Sem data]"}";
        }
    }
}
