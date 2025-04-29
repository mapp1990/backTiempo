using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arq_micro_pru_tiempo.Models
{
    /**
     * Modelo que representa la tabla de usuarios en la base de datos
     */
    public class User
    {
        public int Id { get; set; }
        public int TipDocumentId { get; set; }
        public int TipUserId { get; set; }
        public string NumberDocument { get; set; }

        [MaxLength(40, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string? UserName { get; set; }

        [MinLength(8, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        public string? Password { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string Names { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        public string LastName { get; set; }        
        public DateTime DateTuition { get; set; }
        public bool Active { get; set; }

        [ForeignKey("TipDocumentId")]
        public virtual TipDocument TipDocument { get; set; }

        [ForeignKey("TipUserId")]
        public virtual TipUser TipUser { get; set; }
    }
}
