using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReportRepository : BaseRepository<Review>, IReportRepository
    {
        public ReportRepository(MovieShopAppDbContext c) : base(c)
        {
        }
    }
}
