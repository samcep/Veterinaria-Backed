using Microsoft.AspNetCore.Razor.Hosting;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Mascota { 


        [Key]
        public int IdMascotaId { get; set; }
        [StringLength(maximumLength: 250)]
        [Required]
        public string NombreMascota { get; set; }
        [Required]
        public int Especie { get; set; }
        [Required]
        public int Raza { get;set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public int IdPropietario { get; set; }


    }
}
