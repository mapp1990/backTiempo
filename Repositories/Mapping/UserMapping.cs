using AutoMapper;
using arq_micro_pru_tiempo.Models;
using arq_micro_tiempo.Repositories.DTO;
using arq_micro_tiempo.Repositories.Interfaces;

namespace arq_micro_pru_tiempo.Repositories.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, User_DTO>();
            CreateMap<User_DTO, User>();

            CreateMap<JobOffer, JobOffer_DTO>();
            CreateMap<JobOffer_DTO, JobOffer>();
        }
    }
}
