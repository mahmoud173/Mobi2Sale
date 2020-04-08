using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mobi2saleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public OrdersController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }


        [HttpPost]
        [Route("api/Orders/EditItemQuantityInCart")]
        public async Task<IActionResult> EditItemQuantityInCart(TblOrders data)
        {
            var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

          //  var ClientIdentityId = User.Identity.GetUserId();

                var orderDetailsData = await Db.TblOrderDetails.FirstOrDefaultAsync(o => o.PkOrderDetailsId == data.PkOrdersId);
                orderDetailsData.ModifiedAt = data.ModifiedAt = DateTime.Now;
                orderDetailsData.ModifiedBy = data.ModifiedBy = ClientIdentityId;
                await Db.SaveChangesAsync();
                var orderData = await Db.TblOrders.FirstOrDefaultAsync(o => o.PkOrdersId == data.PkOrdersId);
                orderData.TotalAmount = data.TotalAmount;
                orderData.TotalCost = data.TotalCost;
                await Db.SaveChangesAsync();
                return Ok();
        }

        [HttpPost]
        [Route("api/Orders/PlaceOrder/{id}")]
        public async Task<IActionResult> PlaceOrder(Guid id)
        {
            try
            {
                var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                                                                                      //  var ClientIdentityId = User.Identity.GetUserId();
                var orderData = (await Db.TblOrders.FirstOrDefaultAsync(o => o.PkOrdersId == id));
                orderData.ModifiedAt = DateTime.Now;
                orderData.ModifiedBy = ClientIdentityId;
                orderData.OrderIsOrder = true;
                await Db.SaveChangesAsync();
                return Ok(new { message = " Your Order Has Been Placed Successfully :) " });
            }
            catch (Exception)
            {

                return BadRequest(" Somting Went Wrong :( ");
            }

        }


        [HttpDelete]
        [Route("api/Orders/DeleteItemFromCart/{orderId}")]
        public async Task<IActionResult> DeleteItemFromCart(Guid orderId)
        {
            try
            {
                var orderdetailsData = (await Db.TblOrderDetails.FirstOrDefaultAsync(o => o.OrderId == orderId));
                Db.TblOrderDetails.Remove(orderdetailsData);
                await Db.SaveChangesAsync();


                var orderData = await Db.TblOrders.FirstOrDefaultAsync(o => o.PkOrdersId == orderId);
                Db.TblOrders.Remove(orderData);
                await Db.SaveChangesAsync();

                return Ok(new { message = " item Has Been Removed From Cart Successfully :) " });


            }
            catch (Exception)
            {

                return BadRequest(" Somting Went Wrong :( ");
            }


        }
    }
}