using arq_micro_pru_tiempo.Models;

namespace arq_micro_tiempo.Repositories.DTO
{
    public class JobOffer_DTO
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
