using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync _repository;

        public UserServiceAsync(IUserRepositoryAsync repository)
        {
            _repository = repository;
        }   
    }
}
