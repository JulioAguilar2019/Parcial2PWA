using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_2019GH650_2019AM601.Models
{
    public class casosReportados
    {

        [Key]
        public int casosId { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int departamentosId { get; set; }
        
        [NotMapped]
        public string departamento { get; set; }
        
        [NotMapped]
        public string genero { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public int generoId { get; set; }
        [Required]
        [Display(Name = "Confirmados")]
        public int confirmados { get; set; }
        [Required]
        [Display(Name = "Recuperados")]
        public int recuperados { get; set; }
        [Required]
        [Display(Name = "Fallecidos")]
        public int fallecidos { get; set; }
    }
}
