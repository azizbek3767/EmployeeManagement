using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Start date of work")]
        public DateTime StartDateOfWork { get; set; }

        [Required]
        public Positions? Position { get; set; }

        [Required]
        public string Company { get; set; }
    }
}
