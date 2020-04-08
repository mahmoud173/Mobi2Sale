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
    public class SubCategoriesController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public SubCategoriesController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        [HttpGet]
        [Route("api/SubCategories/GetAllSubCategoryByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetAllCategories(Guid categoryId, string filter = "")
        {
            if (categoryId == null)
            {
                return BadRequest(" Somting Went Wrong :( ");
            }
            try
            {
                if ((string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter))||(!string.IsNullOrEmpty(filter) || !string.IsNullOrWhiteSpace(filter)))
                {
                    var data = await Db.TblSubCategories.
                        Where(c => c.FkCategoriesSubCategoriesCategoryId == categoryId && c.IsDeleted != true).ToListAsync();

                    return Ok(data);
                }
                else
                {
                    return BadRequest(" Somting Went Wrong :( ");
                }

            }
            catch (Exception )
            {

                return NotFound();
            }

        }
    }
}