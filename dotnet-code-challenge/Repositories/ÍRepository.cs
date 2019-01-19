using System.Collections.Generic;

namespace dotnet_code_challenge.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
