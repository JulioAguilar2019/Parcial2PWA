using System.ComponentModel.DataAnnotations;

namespace P2_2019GH650_2019AM601.Models
{
    public class departamentos
    {
        [Key]
        public int departamentosId { get; set; }
        public string departamento { get; set; }
    }
}
