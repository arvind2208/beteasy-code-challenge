using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Services
{
    public class GetHorsesByPriceService : IService<IEnumerable<Horse>>
    {
        private readonly IRepository<Horse> _horseRepository;

        public GetHorsesByPriceService(IRepository<Horse> horseRepository)
        {
            _horseRepository = horseRepository;
        }

        public IEnumerable<Horse> Invoke()
        {
            return _horseRepository.GetAll().OrderBy(x => x.Price);
        }
    }
}
