namespace FurnitureManufacturer.Engine.Factories
{
    using System.Collections.Generic;
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber, new List<IFurniture>());
        }
    }
}
