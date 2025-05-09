using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Tutorial8.Models.DTOs;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        
        // This endpoint retrieves all trips associated with a specific client.
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

        // This endpoint creates a new client record.
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientDTO client)
        {

            var newClientId = _clientsService.AddClient(client);
            
            return Ok($"Client with id {newClientId.Result} was created.");
        }

        // This endpoint registers a client for a specific trip.
        [HttpPut("{id}/trips/{tripId}")]
        public async Task<IActionResult> AssignClientRegistration(int id, int tripId)
        {

            var result = await _clientsService.AssignClientRegistration(id, tripId);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
                
            
            return Ok(result.Message);
        }

        // This endpoint removes a client's registration from a trip.
        [HttpDelete("{id}/trips/{tripdId}")]
        public async Task<IActionResult> DeleteClientRegistration(int id, int tripId)
        {


            return Ok();
        }
    }
}
