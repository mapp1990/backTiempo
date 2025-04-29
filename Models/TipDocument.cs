using System.ComponentModel.DataAnnotations;

namespace arq_micro_pru_tiempo.Models
{
    public class TipDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sigla { get; set; }
    }
}
