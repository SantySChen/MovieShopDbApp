using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repo)
        {
            _repository = repo;
        }
    }
}
