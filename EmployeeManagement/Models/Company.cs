using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeManagement.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public TypesOfBusinessEntity TypeOfBusinessEntity { get; set; }
    }
}
