using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeManagement.Models
{
    public enum TypesOfBusinessEntity
    {
        [Display(Name = "LLC")]
        LLC,
        [Display(Name = "JSC")]
        JSC,
    }
}
