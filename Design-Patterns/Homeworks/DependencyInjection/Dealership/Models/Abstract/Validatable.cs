using System;

using Dealership.Common.Contracts;

namespace Dealership.Models.Abstract
{
    public abstract class Validatable
    {
        private IValidatorProvider _validator;

        protected Validatable(IValidatorProvider validator)
        {
            this.Validator = validator;
        }

        protected IValidatorProvider Validator
        {
            get
            {
                return this._validator; 
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this._validator = value;
            }
        }
    }
}
