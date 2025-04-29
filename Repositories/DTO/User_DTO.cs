using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using arq_micro_pru_tiempo.Models;

namespace arq_micro_tiempo.Repositories.DTO
{
    /**
     * Objeto que se recibe y envia al fontend
     */
    public class User_DTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public int TipDocumentId { get; set; }
        public string NumberDocument { get; set; }
        public DateTime DateTuition { get; set; }
        public int TipUserId { get; set; }
        public bool Active { get; set; }
    }
}
