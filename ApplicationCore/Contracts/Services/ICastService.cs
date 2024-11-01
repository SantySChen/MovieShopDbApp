﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Cast GetCastDetails(int id);

        CastWithMovies GetById(int id);
    }
}
