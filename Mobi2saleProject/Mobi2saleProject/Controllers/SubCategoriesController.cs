using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobi2saleProject.Dtos;

namespace Mobi2saleProject.Controllers
{
    [Authorize]
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
                    var data = (await Db.TblSubCategories.Where(c => c.FkCategoriesSubCategoriesCategoryId == categoryId && c.IsDeleted != true).
                    Select(c => new SubCategoriesDto()
                    {
                        pk_Subcategories_Id = c.PkSubCategoriesId,
                        Name = c.Name,
                        Description = c.Description,
                        ImageUrl = c.ImageUrl,
                        fk_Categories_subCategories_CategoryId = c.FkCategoriesSubCategoriesCategoryId,
                        IsDeleted =(bool) c.IsDeleted
                    }).ToListAsync());

                    return Ok(data);
                }
                else
                {
                    return BadRequest(" Somting Went Wrong :( ");
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}