using System;
using System.Collections.Generic;
using System.Text;
using License.DataAccess.Infrastructure;

namespace License.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly LicenseDbContext _dbContext;

        public UnitOfWork(LicenseDbContext dbContext)
        {
            _dbContext = dbContext;
            ServiceRepository = new ServiceRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
            SubcategoryRepository = new SubcategoryRepository(dbContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override void Complete()
        {
            _dbContext.SaveChanges();
        }
    }
}
