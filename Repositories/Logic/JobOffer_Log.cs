using arq_micro_tiempo.Repositories.DTO;
using arq_micro_tiempo.Repositories.Interfaces;
using arq_micro_pru_tiempo.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace arq_micro_pru_tiempo.Repositories.Logic
{
    public class JobOffer_Log : IJobOffer
    {
        private readonly IMapper _mapper;
        private readonly UserContext _context;

        public JobOffer_Log(IMapper mapper, UserContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /**
         * Metodo que permite obtener el listado de ofertas creadas
         */
        public async Task<List<JobOffer_DTO>> ListOffers()
        {
            var offers = await _context.Offers.Where(x => x.Active == true).ToListAsync();
            //List <JobOffer_DTO> offersList = new List <JobOffer_DTO>();

            /*foreach (var offer in offers)
            {
                User_DTO userOffer = await _context.OfferXUsers
                    .Include(x => x.IdUser)
                    .Where(x => x.IdOffer == offer.Id && x.IdUser == 2)
                    .Select(x => new User_DTO
                    {
                        Id = x.User.Id,
                        Names = x.User.Names,
                        LastName = x.User.LastName,
                        UserName = x.User.UserName,
                        Password = x.User.Password,
                        TipDocumentId = x.User.TipDocumentId,
                        NumberDocument = x.User.NumberDocument,
                        DateTuition = x.User.DateTuition,
                        TipUserId = x.User.TipDocumentId,
                        Active = x.User.Active

                    })
                    .FirstOrDefaultAsync();

                List<User_DTO> users = await _context.OfferXUsers
                    .Include(x => x.IdUser)
                    .Where(x => x.IdOffer == offer.Id && x.IdUser == 3)
                    .Select(x => new User_DTO
                    {
                        Id = x.User.Id,
                        Names = x.User.Names,
                        LastName = x.User.LastName,
                        UserName = x.User.UserName,
                        Password = x.User.Password,
                        TipDocumentId = x.User.TipDocumentId,
                        NumberDocument = x.User.NumberDocument,
                        DateTuition = x.User.DateTuition,
                        TipUserId = x.User.TipDocumentId,
                        Active = x.User.Active

                    })
                    .ToListAsync();

                offersList.Add(
                    new JobOffer_DTO
                    {
                        Id = offer.Id,
                        TitleJob = offer.TitleJob,
                        Description = offer.Description,
                        Location = offer.Location,
                        Salary = offer.Salary,
                        ContractType = offer.ContractType,
                        DatePublish = offer.DatePublish,
                        State = offer.State,
                        Active = offer.Active

                    });
            }*/

            return _mapper.Map<List<JobOffer_DTO>>(offers);
            //return offersList;
        }

        /**
         * Metodo que permite asignar una oferta a un usuario
         */
        public async Task<JobOffer_DTO> CreateOfferForUser(int idOffer, int idUser)
        {
            string accion = "C";

            OfferXUser offersForUser = await _context.OfferXUsers.Where( x => x.IdUser == idUser && x.IdOffer == idOffer).FirstOrDefaultAsync();

            accion = offersForUser != null ? "U" : accion;
            offersForUser = offersForUser == null ? new OfferXUser(): offersForUser;

            offersForUser.IdOffer = idOffer;
            offersForUser.IdUser = idUser;

            if (accion == "C")
            {
                _context.OfferXUsers.Add(offersForUser);
            }
            else
            {
                _context.OfferXUsers.Update(offersForUser);
            }

            var offer = await _context.Offers.Where(x => x.Id == idOffer && x.Active == true).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();

            return _mapper.Map<JobOffer_DTO>(offer);
        }

        /**
         * Metodo que permite crear una oferta
         */
        public async Task<JobOffer_DTO> CreateOffer(JobOffer_DTO JobOffer)
        {
            JobOffer Offer = await _context.Offers.Where(x => x.Id == JobOffer.Id).FirstOrDefaultAsync();
            string accion = "C";

            accion = Offer != null ? "U" : accion;
            Offer = Offer == null ? new JobOffer() : Offer;

            Offer.TitleJob = JobOffer.TitleJob;
            Offer.Description = JobOffer.Description;
            Offer.Location = JobOffer.Location;
            Offer.Salary = JobOffer.Salary;
            Offer.ContractType = JobOffer.ContractType;
            Offer.DatePublish = JobOffer.DatePublish;
            Offer.State = JobOffer.State;
            Offer.Active = JobOffer.Active;

            if (accion == "C")
            {
                _context.Offers.Add(Offer);
            }
            else
            {
                _context.Offers.Update(Offer);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<JobOffer_DTO>(Offer);
        }

        /**
         * Metodo que permite eliminar una oferta
         */
        public async Task<JobOffer_DTO> DeleteOffer(int idJobOffer)
        {
            JobOffer Offer = await _context.Offers.Where(x => x.Id == idJobOffer).FirstOrDefaultAsync();
            Offer.Active = false;

            _context.Offers.Update(Offer);

            await _context.SaveChangesAsync();
            return _mapper.Map<JobOffer_DTO>(Offer);
        }

    }
}