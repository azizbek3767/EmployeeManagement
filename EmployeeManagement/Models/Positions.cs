using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmployeeManagement.Models
{
    public enum Positions
    {
        [Display(Name = "Sowtware Developer")]
        SowtwareDeveloper,
        [Display(Name = "Manual QA")]
        ManualQA,
        [Display(Name = "Business Analyst")]
        BusinessAnalyst,
        [Display(Name = "Project Manager")]
        ProjectManager,
    }

}
