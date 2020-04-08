using Entities.Model;
using Mobi2saleProject.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Models.Data_Access
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {

        private readonly Mobi2saleContext Db;
        public Repository(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }
    }
}
