using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobi2saleProject.Dtos;

namespace Mobi2saleProject.Controllers
{
    
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
                var categoriesData = (await Db.TblCategories.Select(c => new CategoriesDto
                {
                    pk_Categories_Id = c.PkCategoriesId,
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    IsDeleted = (bool)c.IsDeleted,

                    SubCategories = c.TblSubCategories.Select(j => new SubCategory()
                    {
                        pk_SubCategories_Id = j.PkSubCategoriesId,
                        Name = j.Name,

                    }).ToList()

                }).ToListAsync());

                return Ok(categoriesData);
            }
            catch (Exception )
            {

                return NotFound();
            }
            
        }
    }
}