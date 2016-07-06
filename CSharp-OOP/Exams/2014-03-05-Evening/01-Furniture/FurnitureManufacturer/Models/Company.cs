namespace FurnitureManufacturer.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using FurnitureManufacturer.Models.Common;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber, ICollection<IFurniture> furnitures)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = furnitures;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value,
                    string.Format(ErrorMessages.InvalidStringLengthErrorMessage, "Company name", Constants.MinCompanyNameLength), Constants.MinCompanyNameLength);
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(ErrorMessages.NullorEmptyErrorMessage, "Company name"));
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                Validator.CheckIfStringIsExactLength(value, Constants.CompanyRegistrationNumberLength,
                    string.Format(ErrorMessages.StringNotExactLength, "Registration number", Constants.CompanyRegistrationNumberLength));
                Validator.CheckIfStringIsNumbersOnly(value,
                    string.Format(ErrorMessages.StringNotOnlyNumericsErrorMessage, "Registration number"));
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
            private set
            {
                Validator.CheckIfNull(value, string.Format(ErrorMessages.NullorEmptyErrorMessage, "Furnitures"));
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
            //this.Furnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            Validator.CheckIfStringIsNullOrEmpty(model,
                string.Format(ErrorMessages.NullorEmptyErrorMessage, "Model"));
            IFurniture furniture;
            try
            {
                furniture =
                    (from x in this.Furnitures where x.Model.ToLower() == model.ToLower() select x).FirstOrDefault();
            }
            catch
            {
                furniture = null;
            }
            return furniture;
        }

        public string Catalog()
        {
            var output = string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            if (this.Furnitures.Count == 0)
            {
                return output;
            }
            else
            {
                var orderedFurnitures = furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
                foreach (var furniture in orderedFurnitures)
                {
                    output = output + "\n" + furniture;
                }
            }
            return output;
        }
    }
}