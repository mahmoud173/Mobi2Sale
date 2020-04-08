﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mobi2saleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritsController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public FavoritsController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }
    }
}