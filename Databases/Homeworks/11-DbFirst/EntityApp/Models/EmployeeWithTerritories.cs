namespace DbFirst.Models
{
    using System.Data.Linq;

    using Data;

    public class EmployeeWithTerritories : Employee
    {
        public virtual EntitySet<Territory> Territories { get; set; }
    }
}
