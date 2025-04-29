using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace arq_micro_pru_tiempo.Models
{
    /**
     * Modelo que representa la tabla de ofertas en la base de datos
     */
    public class JobOffer
    {
        public int Id { get; set; }
        public string TitleJob { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public string ContractType { get; set; }
        public DateTime DatePublish { get; set; }
        public string State { get; set; }
        public Boolean Active { get; set; }
    }
}
