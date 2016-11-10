namespace SuperheroesUniverse.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        public EfUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                                      .SelectMany(x => x.ValidationErrors)
                                      .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public void Dispose()
        {
        }
    }
}
