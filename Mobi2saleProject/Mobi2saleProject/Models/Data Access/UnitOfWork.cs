using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Mobi2saleProject.Models.Repository;

namespace Mobi2saleProject.Models.Data_Access
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly Mobi2saleContext Db;
        public UnitOfWork(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        public async Task<int> complete()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
