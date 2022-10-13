using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeManagement.ViewModels
{
    public class CompanyCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public TypesOfBusinessEntity TypeOfBusinessEntity { get; set; }
    }
}
