using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio.Models
{
    public class Employee
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Document { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateIn { get; set; }

        public int IdRole { get; set; }
        [ForeignKey("IdRole")]

        public Role? Role { get; set; }
        
    }
}
