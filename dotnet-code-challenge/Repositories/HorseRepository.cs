using dotnet_code_challenge.Models;
using System.Collections.Generic;

namespace dotnet_code_challenge.Repositories
{
    public class HorseRepository : IRepository<Horse>
    {
        private DataSet _dataSet;
        public HorseRepository(DataSet dataSet)
        {
            _dataSet = dataSet;
        }

        public IEnumerable<Horse> GetAll()
        {
            return _dataSet.Horses;
        }
    }
}
