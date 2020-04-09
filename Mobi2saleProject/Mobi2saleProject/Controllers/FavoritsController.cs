using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobi2saleProject.Dtos;

namespace Mobi2saleProject.Controllers
{
    [ApiController]
    public class FavoritsController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public FavoritsController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        [HttpPost]
        [Route("api/Favorites/AddOrRemoveFavorite")]                                            
        public async Task<IActionResult> AddOrRemoveFavorite(FavoritsDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                  var _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                   // var _userId = User.Identity.GetUserId();

                Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(q => q.IdentityId == _userId)).PkClientId;

                var existed = (await Db.TblFavorites.FirstOrDefaultAsync(e => e.FkClientId == clientId && e.FkItemsId == data.ItemID));
                if (existed != null)
                {
                    var saved = await RemoveItemFromFavorites(data.ItemID, clientId);
                    //return saved ? Ok() : BadRequest();
                    if (saved)
                    {
                        return Ok(new { message = " Item has been Deleted From Your Favorite Successfully ..! " });
                    }
                    else
                    {
                        return BadRequest(" Something Went Wrong :( ");
                    }

                }
                else
                {
                    var newFavorite = new TblFavorites()
                    {
                        PkFavoritesId = Guid.NewGuid(),
                        FkItemsId = data.ItemID,
                        FkClientId = clientId,
                    };
                    Db.TblFavorites.Add(newFavorite);
                    await Db.SaveChangesAsync();
                    var location = new Uri(HttpContext.Request.Path + "/" + newFavorite.PkFavoritesId.ToString());//I Edit This line
                    data.pk_Favorites_Id = newFavorite.PkFavoritesId;
                    data.ClientId = newFavorite.FkClientId;
                    return Created(location, data);
                }
        }


        [HttpGet]
        [Route("api/Favorites/GetAllFavoritesToClient/{pageNumber}")]            
        public async Task<IActionResult> GetAllFavoritesToClient(int pageNumber)
        {
            var _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
           // var _userId = User.Identity.GetUserId();
            if (_userId == null)
            {
                return BadRequest(" Something Went Wrong :( ");
            }

            int numberOfObjectsPerPage = 15;

            int skip = numberOfObjectsPerPage * (pageNumber - 1);

                Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(q => q.IdentityId == _userId)).PkClientId;
                var FavoritesData = (await Db.TblFavorites.Where(f => f.FkClientId == clientId).
                OrderBy(d => d.CraetedAt).Skip(skip).Take(numberOfObjectsPerPage).Select(f => new ListClientFavoritsDto()
                {

                    pk_Favorites_Id = f.PkFavoritesId,
                    ClientId = f.FkClientId,
                    pk_Items_Id = f.FkItemsId,
                    Name = f.FkItems.Name,
                    WholesalePrice = f.FkItems.WholesalePrice,
                    Color = f.FkItems.Color,
                    CoverImageUrl = f.FkItems.CoverImageUrl,
                    MainImageUrl = f.FkItems.MainImageUrl,
                    Description = f.FkItems.Description,
                    InitialQuantity = "1",
                    SupplyPrice = f.FkItems.SupplyPrice,
                    IsFavorite = Db.TblFavorites.Where(a => a.FkClientId == clientId && a.FkItemsId == f.FkItemsId).Count() == 1 ? true : false,

                }).ToListAsync());
                return Ok(FavoritesData);
            
        }



        private async Task<bool> RemoveItemFromFavorites(Guid itemId, Guid clientId)         
        {
                if (itemId == null)
                {
                     return false;
                }

                var FavoritesData = (await Db.TblFavorites.FirstOrDefaultAsync(f => f.FkItemsId == itemId && f.FkClientId == clientId));

                if (FavoritesData != null)
                {
                    Db.TblFavorites.Remove(FavoritesData);
                    return await Db.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
        }

    }
}