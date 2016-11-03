using System;
using System.Collections.Generic;
using System.Text;

using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models.Abstract;

namespace Dealership.Models
{
    public class User : Validatable, IUser
    {
        private const string UsernameProperty = "Username";
        private const string FirstNameProperty = "Firstname";
        private const string LastNameProperty = "Lastname";
        private const string PasswordProperty = "Password";
        private const string NoVehiclesHeader = "--NO VEHICLES--";
        private const string UserHeader = "--USER {0}--";

        private string _firstName;
        private string _lastName;
        private string _password;
        private string _username;

        public User(string username,
                    string firstName,
                    string lastName,
                    string password,
                    Role role,
                    IValidatorProvider validator)
            : base(validator)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return this._username; }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, UsernameProperty));
                this.Validator.ValidateSymbols(value, Constants.UsernamePattern,
                                               string.Format(Constants.InvalidSymbols, UsernameProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, UsernameProperty,
                                                              Constants.MinNameLength, Constants.MaxNameLength));

                this._username = value;
            }
        }

        public string FirstName
        {
            get { return this._firstName; }

            private set
            {
                this.ValidateName(value, FirstNameProperty);
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }

            private set
            {
                this.ValidateName(value, LastNameProperty);
                this._lastName = value;
            }
        }

        public string Password
        {
            get { return this._password; }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, PasswordProperty));
                this.Validator.ValidateSymbols(value, Constants.PasswordPattern,
                                               string.Format(Constants.InvalidSymbols, PasswordProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, PasswordProperty,
                                                              Constants.MinPasswordLength, Constants.MaxPasswordLength));

                this._password = value;
            }
        }

        public Role Role { get; }

        public IList<IVehicle> Vehicles { get; }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            this.Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            this.Validator.ValidateNull(vehicleToAddComment, Constants.CommentCannotBeNull);

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            if (this.Role == Role.Normal && this.Vehicles.Count >= 5)
            {
                throw new ArgumentException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
            }

            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }

            this.Vehicles.Add(vehicle);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            this.Validator.ValidateNull(vehicleToRemoveComment, Constants.VehicleCannotBeNull);
            this.Validator.ValidateNull(commentToRemove, Constants.CommentCannotBeNull);

            if (this.Username != commentToRemove.Author)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            this.Vehicles.Remove(vehicle);
        }

        public string PrintVehicles()
        {
            var builder = new StringBuilder();

            var counter = 1;
            builder.AppendLine(string.Format(UserHeader, this.Username));

            if (this.Vehicles.Count <= 0)
            {
                builder.AppendLine(NoVehiclesHeader);
            }
            else
            {
                foreach (var vehicle in this.Vehicles)
                {
                    builder.AppendLine(string.Format("{0}. {1}", counter, vehicle));
                    counter++;
                }
            }

            return builder.ToString().Trim();
        }

        public override string ToString()
        {
            return string.Format(Constants.UserToString, this.Username, this.FirstName, this.LastName, this.Role);
        }

        private void ValidateName(string name, string propertyName)
        {
            this.Validator.ValidateNull(name, string.Format(Constants.PropertyCannotBeNull, propertyName));
            this.Validator.ValidateIntRange(name.Length, Constants.MinNameLength, Constants.MaxNameLength,
                                            string.Format(Constants.StringMustBeBetweenMinAndMax, propertyName,
                                                          Constants.MinNameLength, Constants.MaxNameLength));
        }
    }
}
