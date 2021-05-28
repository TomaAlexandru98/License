using System;
using System.Collections.Generic;
using System.Text;
using License.DataAccess.Repositories;

namespace License.DataAccess.Infrastructure
{
    public abstract class IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; protected set; }
        public ServiceRepository ServiceRepository { get; protected set; }
        public CategoryRepository CategoryRepository { get; protected set; }
        public SubcategoryRepository SubcategoryRepository { get; protected set; }

        public abstract void Complete();

        public abstract void Dispose();
    }
}
