using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository repo)
        {
            _castRepository = repo;
        }

        public CastWithMovies GetById(int id)
        {
            return _castRepository.GetById(id);
        }

        public Cast GetCastDetails(int id)
        {
            return _castRepository.GetCastDetails(id);
        }
    }
}
