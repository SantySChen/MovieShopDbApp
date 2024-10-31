using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreServiceAsync : IGenreServiceAsync
    {
        private readonly IGenreRepositoryAsync _genreRepository;

        public GenreServiceAsync(IGenreRepositoryAsync genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<int> AddGenreAsync(Genre genre)
        {
            return await _genreRepository.InsertAsync(genre);
        }

        public async Task<int> DeleteGenreAsync(int id)
        {
            return await _genreRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenreAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGerneByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateGenreAsync(Genre genre, int id)
        {
            if (genre.Id == id)
            {
                return await _genreRepository.UpdateAsync(genre);
            }
            return 0;
        }
    }
}
