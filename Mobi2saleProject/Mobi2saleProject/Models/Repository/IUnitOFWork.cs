using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Models.Repository
{
    interface IUnitOFWork:IDisposable
    {
         Task<int> complete();

    }
}
