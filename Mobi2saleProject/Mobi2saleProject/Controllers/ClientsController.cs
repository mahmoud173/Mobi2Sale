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
    public class ClientsController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public ClientsController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        [HttpPost]
        [Route("api/Clients/ClientEditProfile")]
        public async Task<IActionResult> ClientEditProfile(ClientEditProfileDto data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                HelpFunctionsController helpFunction = new HelpFunctionsController();
                var IdentityClientId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
                  // var IdentityClientId = User.Identity.GetUserId();
              //  var IdentityEmail = await Db.AspNetUsers.FirstOrDefaultAsync(q => q.Id == IdentityClientId);
                var clientData = await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == IdentityClientId);
                clientData.Name = data.Name;
                clientData.ManagerName = data.ManagerName;
                clientData.Mobile1 = data.Mobile1;
                clientData.Mobile2 = data.Mobile2;
                clientData.Phone = data.Phone;
                clientData.Email = data.Email;
              //  IdentityEmail.Email = data.Email;
                clientData.Fax = data.Fax;
                clientData.ModifiedAt = DateTime.Now;
                clientData.ModifiedBy = IdentityClientId;
                await Db.SaveChangesAsync();
                return Ok(data);
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }



        [HttpGet]
        [Route("api/Clients/ClientViewProfile")]
        public async Task<IActionResult> ClientViewProfile()
        {


            try
            {
                var IdentityClientId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId

                // var IdentityClientId = User.Identity.GetUserId();
                var data = await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == IdentityClientId);
                if (data == null)
                {
                    return BadRequest(" Something Went Wrong :( ");
                }
                var clientData = new ClientViewProfile()
                {
                    Name = data.Name,
                    ManagerName = data.ManagerName,
                    Mobile1 = data.Mobile1,
                    Mobile2 = data.Mobile2,
                    Phone = data.Phone,
                    Email = data.Email,
                    Fax = data.Fax,
                    Address = data.Address,
                };
                return Ok(clientData);
            }
            catch (Exception)
            {
                return NotFound();
            }
              
        }
    }

}