using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mobi2saleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public CategoriesController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        [HttpGet]
        [Route("api/Categories/GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var CategoriesData = await Db.TblCategories.ToListAsync();
                return Ok(CategoriesData);
            }
            catch (Exception )
            {

                return NotFound();
            }
            
        }
    }
}