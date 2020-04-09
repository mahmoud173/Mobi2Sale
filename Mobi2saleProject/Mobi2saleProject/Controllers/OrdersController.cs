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
    public class OrdersController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public OrdersController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }


        [HttpPost]
        [Route("api/Orders/AddOrder")]
        public async Task<IActionResult> AddOrder(OrdersDto data)
        {
            if (!ModelState.IsValid || data.TotalCost > data.TotalAmount)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

                // var ClientIdentityId = User.Identity.GetUserId();

                var clientId = (await Db.TblClient.FirstOrDefaultAsync(q => q.IdentityId == ClientIdentityId)).PkClientId;

                var orderData = new TblOrders
                {
                    PkOrdersId = data.OrderId = Guid.NewGuid(),
                    OrderDate = data.Order_Date = DateTime.Now,
                    TotalAmount = data.TotalAmount,
                    TotalCost = data.TotalCost,
                    FkClientsOrdersClientId = data.ClientId = clientId,
                    CraetedAt = data.CraetedAt = DateTime.Now,
                    CreatedBy = data.CreatedBy = data.CreatedBy = ClientIdentityId,
                    ModifiedAt = data.ModifiedAt = DateTime.Now,
                    ModifiedBy = data.ModifiedBy = data.ModifiedBy = ClientIdentityId,
                    OrderIsOrder = data.Order_IsOrder = true,
                    IsCancelled = data.IsCancelled = false,
                    IsDeleted = data.IsDeleted = false,
                    OnDelivery = data.OnDelivery = false,
                    OrderIsPaid = data.Order_IsPaid = false,
                    OrderNo = data.OrderNo = Db.TblOrders.Count() + 1,

                };
                Db.TblOrders.Add(orderData);


                if (orderData.TblOrderDetails != null)
                {

                    foreach (var item in data.OrderDetails)
                    {
                        var itemData = (await Db.TblItems.Where(i => i.PkItemsId == item.fk_Items_Id).FirstOrDefaultAsync());

                        if (item.Quantity > itemData.Available)
                        {
                            return BadRequest("please select a valid quantity for item :" + itemData.Name);
                        }
                    }


                    foreach (var item in data.OrderDetails)
                    {
                        var itemData = (await Db.TblItems.Where(i => i.PkItemsId == item.fk_Items_Id).FirstOrDefaultAsync());
                        itemData.BookedUp = itemData.BookedUp + item.Quantity;
                        await Db.SaveChangesAsync();
                        var orderDetailsData = new TblOrderDetails
                        {
                            PkOrderDetailsId = item.OrderDetailId = Guid.NewGuid(),
                            OrderId = orderData.PkOrdersId,
                            FkItemsId = item.fk_Items_Id,
                            Quantity = item.Quantity,
                            CraetedAt = item.CraetedAt = DateTime.Now,
                            CreatedBy = item.ModifiedBy = ClientIdentityId,
                            ModifiedAt = item.ModifiedAt = DateTime.Now,
                            ModifiedBy = item.ModifiedBy = ClientIdentityId
                        };
                        Db.TblOrderDetails.Add(orderDetailsData);
                    }

                }
                await Db.SaveChangesAsync();
                return Ok(new { message = " Your order has been placed successfully :)  With OrderNo : (" + data.OrderNo + ")" });

            }
            catch (Exception)
            {
                return BadRequest();
            }

               
        }


        [HttpGet]
        [Route("api/Orders/ViewClientOrders")]
        public async Task<IActionResult> ViewClientOrders()
        {

            try
            {
                var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                // var ClientIdentityId = User.Identity.GetUserId();
                Guid clientId = (await Db.TblClient.FirstOrDefaultAsync(o => o.IdentityId == ClientIdentityId)).PkClientId;
                var clientOrders = (await Db.TblOrders.Where(o => o.FkClientsOrdersClientId == clientId).OrderByDescending(o => o.OrderNo).Select(o => new ClientOrderListDto()
                {
                    OrderId = o.PkOrdersId,
                    Order_Date = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    TotalCost = o.TotalCost,
                    IsCancelled = (bool)o.IsCancelled,
                    Order_IsPaid = (bool)o.OrderIsPaid,
                    OrderNo = o.OrderNo,
                }).ToListAsync());
                return Ok(clientOrders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Orders/ViewClientOrderDetails/{orderId}")]
        public async Task<IActionResult> ViewClientOrderDetails(Guid orderId)
        {
            if (orderId == null)
            {
                return BadRequest(" Something Went Wrong :( ");
            }
            try
            {
                Guid id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var orderDetails = (await Db.TblOrderDetails.Where(o => o.OrderId == orderId).Select(o => new ViewOrderDetailsDto()
                {

                    OrderDetailId = o.PkOrderDetailsId,
                    fk_Items_Id = o.FkItems.PkItemsId,
                    Name = o.FkItems.Name,
                    Quantity = o.Quantity,
                    WholesalePrice = o.FkItems.WholesalePrice,
                    CoverImageUrl = o.FkItems.CoverImageUrl,

                }).ToListAsync());
                return Ok(orderDetails);
            }
            catch (Exception)
            {
                return BadRequest();
            }

                    
        }


        [HttpPost]
        [Route("api/Orders/AddItemToCart")]
        public async Task<IActionResult> AddItemToCart(AddItemToCartDto data)
        {
            try
            {
                var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                                                                                      // var ClientIdentityId = User.Identity.GetUserId();
                var cartOrderId = (await Db.TblOrders.FirstOrDefaultAsync(c => c.OrderIsOrder == false && c.CreatedBy == ClientIdentityId));

                if (cartOrderId == null)
                {

                    var clientId = (await Db.TblClient.FirstOrDefaultAsync(q => q.IdentityId == ClientIdentityId)).PkClientId;

                    var orderData = new TblOrders
                    {
                        PkOrdersId = data.OrderId = Guid.NewGuid(),
                        OrderDate = data.Order_Date = DateTime.Now,
                        TotalAmount = data.TotalAmount,
                        TotalCost = data.TotalCost,
                        FkClientsOrdersClientId = data.ClientId = clientId,
                        CraetedAt = data.CraetedAt = DateTime.Now,
                        CreatedBy = data.CreatedBy = data.CreatedBy = ClientIdentityId,
                        ModifiedAt = data.ModifiedAt = DateTime.Now,
                        ModifiedBy = data.ModifiedBy = data.ModifiedBy = ClientIdentityId,
                        OrderIsOrder = data.Order_IsOrder = false,
                        IsCancelled = data.IsCancelled = false,
                        IsDeleted = data.IsDeleted = false,
                        OnDelivery = data.OnDelivery = false,
                        OrderIsPaid = data.Order_IsPaid = false,
                    };

                    Db.TblOrders.Add(orderData);

                    await Db.SaveChangesAsync();

                    var orderDetailsData = new TblOrderDetails
                    {
                        PkOrderDetailsId = data.OrderDetailId = Guid.NewGuid(),
                        OrderId = orderData.PkOrdersId,
                        FkItemsId = data.ItemId,
                        CraetedAt = data.CraetedAt = DateTime.Now,
                        CreatedBy = ClientIdentityId,
                        ModifiedAt = data.ModifiedAt = DateTime.Now,
                        ModifiedBy = data.ModifiedBy = ClientIdentityId,
                        Quantity = 1, //??
                    };

                    Db.TblOrderDetails.Add(orderDetailsData);
                    await Db.SaveChangesAsync();
                    return Ok(new { message = " Your Order Has Been Placed Successfully :) " });

                }
                else if (cartOrderId != null)
                {

                    var editeOrder = (await Db.TblOrders.FirstOrDefaultAsync(o => o.PkOrdersId == cartOrderId.PkOrdersId && o.OrderIsOrder != true));


                    editeOrder.OrderDate = data.Order_Date = DateTime.Now;
                    editeOrder.TotalAmount = data.TotalAmount;
                    editeOrder.TotalCost = data.TotalCost;
                    editeOrder.ModifiedAt = data.ModifiedAt = DateTime.Now;
                    editeOrder.ModifiedBy = data.ModifiedBy = data.ModifiedBy = ClientIdentityId;


                    await Db.SaveChangesAsync();


                    var orderDetailsData = new TblOrderDetails
                    {
                        PkOrderDetailsId = data.OrderDetailId = Guid.NewGuid(),
                        OrderId = cartOrderId.PkOrdersId,
                        FkItemsId = data.ItemId,
                        CraetedAt = data.CraetedAt = DateTime.Now,
                        CreatedBy = ClientIdentityId,
                        ModifiedAt = data.ModifiedAt = DateTime.Now,
                        ModifiedBy = data.ModifiedBy = ClientIdentityId,
                        Quantity = 1,

                    };
                    Db.TblOrderDetails.Add(orderDetailsData);

                    await Db.SaveChangesAsync();

                    return Ok(new { message = " Your Order Has Been Placed Successfully :) " });
                }
                else
                {
                    return BadRequest(" Something Went Wrong :( ");
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }


        [HttpPost]
        [Route("api/Orders/EditItemQuantityInCart")]
        public async Task<IActionResult> EditItemQuantityInCart(EditOrderQuantityDto data)
        {

            var ClientIdentityId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

          //  var ClientIdentityId = User.Identity.GetUserId();

                var orderDetailsData = await Db.TblOrderDetails.FirstOrDefaultAsync(o => o.PkOrderDetailsId == data.orderDetailId);

                orderDetailsData.ModifiedAt = data.ModifiedAt = DateTime.Now;
                orderDetailsData.ModifiedBy = data.ModifiedBy = ClientIdentityId;
                orderDetailsData.Quantity = data.Quantity;

                await Db.SaveChangesAsync();

                var orderData = await Db.TblOrders.FirstOrDefaultAsync(o => o.PkOrdersId == data.orderId);

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