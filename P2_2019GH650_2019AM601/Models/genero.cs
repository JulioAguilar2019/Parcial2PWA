using System.ComponentModel.DataAnnotations;

namespace P2_2019GH650_2019AM601.Models
{
    public class genero
    {
        [Key]
        public int generoId { get; set; }

        public string generos { get; set; }
    }
}
