using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using System.Security.Claims;

namespace Mobi2saleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public ItemsController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

    }
}