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
    public class CastServiceAsync : ICastServiceAsync
    {
        private readonly ICastRepositoryAsync _castRepository;
        public CastServiceAsync(ICastRepositoryAsync castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastWithMovies> GetByIdAsync(int id)
        {
            return await _castRepository.GetByIdAsync(id);
        }

        public async Task<Cast> GetCastDetailsAsync(int id)
        {
            return await _castRepository.GetCastDetailsAsync(id);
        }
    }
}
