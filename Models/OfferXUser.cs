using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arq_micro_pru_tiempo.Models
{
    public class OfferXUser
    {
        public int Id { get; set; }
        public int IdOffer { get; set; }
        public int IdUser { get; set; }
        public Boolean Active { get; set; }


        [ForeignKey("IdOffer")]
        public virtual JobOffer JobOffer { get; set;}

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
