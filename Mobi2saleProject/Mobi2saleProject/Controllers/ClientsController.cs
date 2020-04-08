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
    public class ClientsController : ControllerBase
    {
        private readonly Mobi2saleContext Db;
        public ClientsController(Mobi2saleContext DbContext)
        {
            Db = DbContext;
        }

        [HttpPost]
        [Route("api/Clients/ClientEditProfile")]
        public async Task<IActionResult> ClientEditProfile(TblClient data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var IdentityClientId = User.Identity.Name;
                var IdentityEmail = await Db.AspNetUsers.FirstOrDefaultAsync(q => q.Id == IdentityClientId);
                var clientData = await Db.TblClient.FirstOrDefaultAsync(c => c.IdentityId == IdentityClientId);
                clientData.ModifiedAt = DateTime.Now;
                clientData.ModifiedBy = IdentityClientId;
                await Db.SaveChangesAsync();
                return Ok(data);

        }

    }
    
}