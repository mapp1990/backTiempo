using arq_micro_tiempo.Repositories.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace arq_micro_tiempo.Repositories.Interfaces
{
    public interface IJobOffer
    {
        Task<List<JobOffer_DTO>> ListOffers();
        Task<JobOffer_DTO> CreateOfferForUser(int idOffer, int idUser);
        Task<JobOffer_DTO> CreateOffer(JobOffer_DTO JobOffer);
        Task<JobOffer_DTO> DeleteOffer(int idJobOffer);

    }
}
