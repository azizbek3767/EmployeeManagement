using System;

namespace EmployeeManagement.Models.Extensions
{
    public static class ExtensionMethods
    {
        public static string UIFriendlyEnum(this Positions position)
        {
            switch (position)
            {
                case Positions.SowtwareDeveloper:
                    return "Sowtware Developer";
                case Positions.ManualQA:
                    return "Manual QA";
                case Positions.BusinessAnalyst:
                    return "Business Analyst";
                case Positions.ProjectManager:
                    return "Project Manager";
            }
            return "Error";
        }
    }

}
