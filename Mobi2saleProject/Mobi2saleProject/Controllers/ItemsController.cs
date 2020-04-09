using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Mobi2saleProject.Dtos;

namespace Mobi2saleProject.Controllers
{
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
                                                                                        //var identityID = User.Identity.GetUserId();
                        Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == identityID)).PkClientId;
                        var data = (await Db.TblItems.
                        Where(i => i.FkSubCategoriesItemsSubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0).
                        OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).
                        Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
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
                        OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
                            OfferPrice = (i.FkOffersItemsOffer.ReadOnly.Equals(false) && i.FkOffersItemsOffer.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.FkOffersItemsOffer.OfferPctg * i.WholesalePrice),
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
                        var identityID = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                                                                                        // var identityID = User.Identity.GetUserId();
                        Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == identityID)).PkClientId;

                        var data = (await Db.TblItems.
                        Where(i => i.FkSubCategoriesItemsSubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0 && i.FkSubCategoriesItemsSubcategoryId.ToString()
                        .Contains(filter)).OrderBy(i => i.Name).
                        Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
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
                        Where(i => i.FkSubCategoriesItemsSubcategoryId == SubCategoryId && i.IsDeleted != true && i.Quantity > 0 && i.FkSubCategoriesItemsSubcategoryId.ToString().
                        Contains(filter)).
                        OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
                            OfferPrice = (i.FkOffersItemsOffer.ReadOnly.Equals(false) && i.FkOffersItemsOffer.IsActive.Equals(true)) ? i.WholesalePrice - (i.FkOffersItemsOffer.OfferPctg * i.WholesalePrice) : 0,
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


        [HttpGet]
        [Route("api/Items/GetIAllItemsInMobileCategory/{pageNumber}")]
        public async Task<IActionResult> GetIAllItemsInMobileCategory(int pageNumber, string filter = "")
        {

            try
            {
                int numberOfObjectsPerPage = 15;
                int skip = numberOfObjectsPerPage * (pageNumber - 1);
                var mobileCategoryId = "15966C87-9B81-4D2F-A5E1-08D79C2DAD52";
                Guid id = Guid.Parse(mobileCategoryId);
                if (string.IsNullOrEmpty(filter) || string.IsNullOrWhiteSpace(filter))
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var identityID = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

                        // var identityID = User.Identity.GetUserId();

                        Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == identityID)).PkClientId;

                        var data = (await Db.TblItems.Where(i => i.FkSubCategoriesItemsSubcategory.FkCategoriesSubCategoriesCategoryId == id && i.IsDeleted != true && i.Quantity > 0).
                            OrderBy(i => i.Name).
                        Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {

                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
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
                        var data = (await Db.TblItems.Where(i => i.FkSubCategoriesItemsSubcategory.FkCategoriesSubCategoriesCategoryId == id && i.IsDeleted != true && i.Quantity > 0).
                        OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
                            OfferPrice = (i.FkOffersItemsOffer.ReadOnly.Equals(false) && i.FkOffersItemsOffer.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.FkOffersItemsOffer.OfferPctg * i.WholesalePrice),
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
                        var identityID = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

                        // var identityID = User.Identity.GetUserId();

                        Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == identityID)).PkClientId;

                        var data = (await Db.TblItems.Include(i => i.TblFavorites).
                        Where(i => i.FkSubCategoriesItemsSubcategory.FkCategoriesSubCategoriesCategoryId == id && i.IsDeleted != true && i.Quantity > 0 && i.FkSubCategoriesItemsSubcategoryId.ToString().
                        Contains(filter)).OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
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
                        Where(i => i.FkSubCategoriesItemsSubcategory.FkCategoriesSubCategoriesCategoryId == id && i.IsDeleted != true && i.Quantity > 0 && i.FkSubCategoriesItemsSubcategoryId.ToString().
                        Contains(filter)).OrderBy(i => i.Name).Skip(skip).Take(numberOfObjectsPerPage).Select(i => new ListItemDto()
                        {
                            pk_Items_Id = i.PkItemsId,
                            Name = i.Name,
                            Description = i.Description,
                            IsInOffer = i.FkOffersItemsOffer.ReadOnly.Equals(true) ? false : true,
                            SupplyPrice = i.SupplyPrice,
                            WholesalePrice = i.WholesalePrice,
                            OfferPctg = i.FkOffersItemsOffer.OfferPctg,
                            OfferPrice = (i.FkOffersItemsOffer.ReadOnly.Equals(false) && i.FkOffersItemsOffer.IsActive.Equals(true)) ? 0 : i.WholesalePrice - (i.FkOffersItemsOffer.OfferPctg * i.WholesalePrice),
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


        [HttpGet]
        [Route("api/Items/GetItemDetailsByItemID/{itemID}")]
        public async Task<IActionResult> GetItemDetailsByItemID(Guid itemID)
        {

            try
            {
                if (itemID == null)
                {
                    return BadRequest(" Somting Went Wrong :( ");
                }

                var data = (await Db.TblItems.FirstOrDefaultAsync(i => i.PkItemsId == itemID && i.Quantity > 0 && i.IsDeleted != true));
                if (data == null)
                {
                    return BadRequest(" Somting Went Wrong :( ");
                }
                var itemdata = new ItemDetailsDto()
                {
                    pk_Items_Id = data.PkItemsId,
                    Name = data.Name,
                    Description = data.Description,
                    MainImageUrl = data.MainImageUrl,
                    Code = data.Code,
                    Color = data.Color,
                    Quantity = data.Quantity,
                    SafeLimit = data.SafeLimit,
                    RetailPrice = data.RetailPrice,
                    SupplyPrice = data.SupplyPrice,
                    WholesalePrice = data.WholesalePrice,
                    IsDeleted = (bool)data.IsDeleted,
                    fk_subCategories_Items_SubcategoryId = data.FkSubCategoriesItemsSubcategoryId,
                    InitialQuantity = "1",
                };
                return Ok(itemdata);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }
    }
}