﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICastRepository : IRepository<Cast>
    {
        CastWithMovies GetById(int id);
        Cast GetCastDetails(int id);
    }
}
