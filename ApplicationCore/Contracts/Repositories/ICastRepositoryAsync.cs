using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICastRepositoryAsync : IRepositoryAsync<Cast>
    {
        Task<CastWithMovies> GetByIdAsync(int id);
        Task<Cast> GetCastDetailsAsync(int id);
    }
}
