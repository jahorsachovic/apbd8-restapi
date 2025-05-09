using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        
        [HttpGet("{id}/trips")]
        public async Task<IActionResult> GetClientTrips(int id)
        {
            var clientTrips = await _clientsService.GetClientTrips(id);

            if (clientTrips.IsNullOrEmpty())
            {
                return NotFound($"Client does not have any trips or does not exist.");
            }
            
            return Ok(clientTrips);
        }
    }
}
