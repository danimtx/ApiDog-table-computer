using System.ComponentModel.DataAnnotations;

namespace ApiDog_table_computer.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "La longitud es maxima de 150 caracteres para {0}")]
        //[RegularExpression(@"\S+", ErrorMessage = "El campo {0} no puede estar vacío o solo contener espacios en blanco.")]
        public string Placa { get; set; } = string.Empty;

        [Required]
        public float Procesador { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El valor de {0} debe ser mayor a 0.")]
        public int Ram { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El valor de {0} debe ser mayor a 0.")]
        public int SSD { get; set; }

        [Required]
        public DateTime Firmware { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "La longitud es maxima de 150 caracteres para {0}")]
        //[RegularExpression(@"\S+", ErrorMessage = "El campo {0} no puede estar vacío o solo contener espacios en blanco.")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
