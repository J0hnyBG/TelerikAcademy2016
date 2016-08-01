namespace Dealership.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class User : IUser
    {
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _password;

        public User(string username, string firstName, string lastName, string password, Role role)
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
            get { return this._userName; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Username", Constants.MinNameLength,
                        Constants.MaxNameLength));
                Validator.ValidateSymbols(value, Constants.UsernamePattern,
                    string.Format(Constants.InvalidSymbols, "Username"));
                this._userName = value;
            }
        }

        public string FirstName
        {
            get { return this._firstName; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Firstname", Constants.MinNameLength,
                        Constants.MaxNameLength));
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinNameLength, Constants.MaxNameLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Lastname", Constants.MinNameLength,
                        Constants.MaxNameLength));
                this._lastName = value;
            }
        }

        public string Password
        {
            get { return this._password; }
            private set
            {
                Validator.ValidateSymbols(value, Constants.PasswordPattern,
                    string.Format(Constants.InvalidSymbols, "Password"));
                Validator.ValidateIntRange(value.Length, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Password", Constants.MinPasswordLength,
                        Constants.MaxPasswordLength));

                this._password = value;
            }
        }

        public Role Role { get; private set; }
        public IList<IVehicle> Vehicles { get; private set; }

        public void AddVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);
            if (this.Role != Role.Admin)
            {
                if (this.Role != Role.VIP && this.Vehicles.Count >= Constants.MaxVehiclesToAdd )
                {
                    throw new InvalidOperationException(string.Format(Constants.NotAnVipUserVehiclesAdd, Constants.MaxVehiclesToAdd));
                }
                this.Vehicles.Add(vehicle);
            }
            else
            {
                throw new InvalidOperationException(Constants.AdminCannotAddVehicles);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            if (this.Vehicles.Contains(vehicle))
            {
                this.Vehicles.Remove(vehicle);
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            Validator.ValidateNull(commentToAdd, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToAddComment, Constants.VehicleCannotBeNull);
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            Validator.ValidateNull(commentToRemove, Constants.CommentCannotBeNull);
            Validator.ValidateNull(vehicleToRemoveComment, Constants.VehicleCannotBeNull);
            if (commentToRemove.Author != this.Username)
            {
                throw new InvalidOperationException(Constants.YouAreNotTheAuthor);
            }
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.Append("--USER " + this.Username + "--");
            if (this.Vehicles.Count == 0)
            {
                sb.Append("\n--NO VEHICLES--");
                return sb.ToString();
            }
            for (int i = 0; i < this.Vehicles.Count; i++)
            {
                sb.Append("\n" + (i+1) + ". " + Vehicles[i].Type + ":");
                sb.Append(Vehicles[i].ToString());

            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return string.Format(Constants.UserToString + ", Role: " + this.Role.ToString(), this.Username, this.FirstName, this.LastName);

        }
    }
}