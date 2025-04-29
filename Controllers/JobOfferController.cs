using Microsoft.AspNetCore.Mvc;
using arq_micro_tiempo.Repositories.Interfaces;
using arq_micro_tiempo.Repositories.DTO;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

namespace arq_micro_pru_tiempo.Controllers
{
    [ApiController]
    [Route("api/ofertas")]

    /**
    * Servicios HTTP Controlador Ofertas
    */
    public class JobOfferController : ControllerBase
    {
        public readonly IJobOffer _offer;

        public JobOfferController(IJobOffer offer)
        {
            _offer = offer;
        }

        /**
         * Servicio de asignacion de una ofertas
         */
        [HttpPost("asignar"), Authorize]
        public async Task<ActionResult<JobOffer_DTO>> PostCreateOfferForUser(OfferXUser_DTO request)
        {
            JobOffer_DTO offerOut = await _offer.CreateOfferForUser(request.idOffer, request.idUser);
            return offerOut == null ? NotFound() : offerOut;
        }

        /**
         * Servicio de creacion de una oferta
         */
        [HttpPost("crear"), Authorize]
        public async Task<ActionResult<JobOffer_DTO>> PostCreateOffer(JobOffer_DTO Offer)
        {
            JobOffer_DTO offerOut = await _offer.CreateOffer(Offer);
            return offerOut == null ? NotFound() : offerOut;
        }

        /**
         * Servicio de eliminación de una oferta
         */
        [HttpPut("eliminar"), Authorize]
        public async Task<ActionResult<JobOffer_DTO>> PutDeleteOffer(JobOffer_DTO request)
        {
            JobOffer_DTO OutResponse = await _offer.DeleteOffer(request.Id);
            return OutResponse;
        }

        /**
         * Servicio de eliminación de una oferta
         */
        [HttpGet("listar"), Authorize]
        public async Task<ActionResult<List<JobOffer_DTO>>> PutListOffers()
        {
            List<JobOffer_DTO> OutResponse = await _offer.ListOffers();
            return OutResponse;
        }
    }
}
