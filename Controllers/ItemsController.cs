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

        [HttpGet]
        [Route("api/Items/GetItemsBySubCategoryId/{SubCategoryId}/{pageNumber}")]
        public async Task<IActionResult> GetItemsBySubCategoryId(Guid SubCategoryId, int pageNumber, string filter = "")
        {
            try
            {
                if (SubCategoryId == null)
                {
                    return BadRequest(" Somting Went Wrong :( ");
                }
                int numberOfObjectsPerPage = 15;
                int skip = numberOfObjectsPerPage * (pageNumber - 1);
          
                    if (string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter))
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            var identityID = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                           // var identityID = User.Identity.GetUserId();
                            Guid clientId = (Db.TblClient.FirstOrDefault(c => c.IdentityId == identityID)).PkClientId;


                            var data = (await Db.TblItems.
                            Where(i => i.FkSubCategoriesItemsSubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0).
                            OrderBy(i => i.Name).Skip(skip).
                            Take(numberOfObjectsPerPage).
                            Select(i => new TblItems()
                            {
                                PkItemsId = i.PkItemsId,
                                Name = i.Name,
                                Description = i.Description,
                                FkOffersItemsOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                                SupplyPrice = i.SupplyPrice,
                                WholesalePrice = i.WholesalePrice,
                                FkOffersItemsOffer = i.FkOffersItemsOffer.OfferPctg,
                                OfferPrice = (i.FkOffersItemsOffer.ReadOnly.Equals(false) && i.FkOffersItemsOffer.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.FkOffersItemsOffer.OfferPctg * i.WholesalePrice),
                                Color = i.Color,
                                CoverImageUrl = i.CoverImageUrl,
                                Quantity = i.Quantity,
                                InitialQuantity = "1",
                                IsFavorite = i.TblFavorites.Where(f => f.FkClientId == clientId && f.FkItemsId == i.PkItemsId).Count() == 1 ? true : false

                            }).ToListAsync());

                            return Ok(data);
                        }

                        else
                        {

                            var data = (await Db.TblItems.
                            Where(i => i.FkSubCategoriesItemsSubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0).
                            OrderBy(i => i.Name).
                            Skip(skip).Take(numberOfObjectsPerPage).Select(i => new TblItems()
                            {
                                PkItemsId = i.pk_Items_Id,
                                Name = i.Name,
                                Description = i.Description,
                                IsInOffer = i.tbl_Offers.ReadOnly.Equals(true) ? false : true,
                                SupplyPrice = i.SupplyPrice,
                                WholesalePrice = i.WholesalePrice,
                                OfferPctg = i.tbl_Offers.OfferPctg,
                                OfferPrice = (i.tbl_Offers.ReadOnly.Equals(false) && i.tbl_Offers.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.tbl_Offers.OfferPctg * i.WholesalePrice),
                                Color = i.Color,
                                CoverImageUrl = i.CoverImageUrl,
                                Quantity = i.Quantity,
                                InitialQuantity = "1",
                                IsFavorite = false
                            }).ToListAsync());

                            return Ok(data);
                        }


                    }

                    else if (!string.IsNullOrEmpty(filter) || !string.IsNullOrWhiteSpace(filter))
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            var identityID = User.Identity.GetUserId();

                            Guid clientId = (await entities.tbl_Client.FirstOrDefaultAsync(c => c.IdentityId == identityID)).pk_Client_Id;

                            var data = (await entities.tbl_Items.Include(i => i.tbl_Favorites).Where(i => i.fk_subCategories_Items_SubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0 && i.fk_subCategories_Items_SubcategoryId.ToString().Contains(filter)).OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                            {
                                pk_Items_Id = i.pk_Items_Id,
                                Name = i.Name,
                                Description = i.Description,
                                IsInOffer = i.tbl_Offers.ReadOnly.Equals(true) ? false : true,
                                SupplyPrice = i.SupplyPrice,
                                WholesalePrice = i.WholesalePrice,
                                OfferPctg = i.tbl_Offers.OfferPctg,
                                OfferPrice = (i.tbl_Offers.ReadOnly.Equals(false) && i.tbl_Offers.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.tbl_Offers.OfferPctg * i.WholesalePrice),
                                Color = i.Color,
                                CoverImageUrl = i.CoverImageUrl,
                                Quantity = i.Quantity,
                                InitialQuantity = "1",
                                IsFavorite = i.tbl_Favorites.Where(f => f.fk_Client_Id == clientId && f.fk_Items_Id == i.pk_Items_Id).Count() == 1 ? true : false

                            }).ToListAsync());

                            return Ok(data);
                        }

                        else
                        {
                            var data = (await entities.tbl_Items.Where(i => i.fk_subCategories_Items_SubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0 && i.fk_subCategories_Items_SubcategoryId.ToString().Contains(filter)).OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                            {
                                pk_Items_Id = i.pk_Items_Id,
                                Name = i.Name,
                                Description = i.Description,
                                IsInOffer = i.tbl_Offers.ReadOnly.Equals(true) ? false : true,
                                SupplyPrice = i.SupplyPrice,
                                WholesalePrice = i.WholesalePrice,
                                OfferPctg = i.tbl_Offers.OfferPctg,
                                OfferPrice = (i.tbl_Offers.ReadOnly.Equals(false) && i.tbl_Offers.IsActive.Equals(true)) ? i.WholesalePrice - (i.tbl_Offers.OfferPctg * i.WholesalePrice) : 0,
                                Color = i.Color,
                                CoverImageUrl = i.CoverImageUrl,
                                Quantity = i.Quantity,
                                InitialQuantity = "1",
                                IsFavorite = false

                            }).ToListAsync());

                            return Ok(data);
                        }
                    }

                    else
                    {
                        return BadRequest(" Somting Went Wrong :( ");

                    }

                
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}