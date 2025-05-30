using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }
        
        // This endpoint retrieves all available trips with their basic information.
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripsService.GetTrips();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrip(int id)
        {
            var trip = await _tripsService.GetTrip(id);
            // if( await DoesTripExist(id)){
            //  return NotFound();
            // }

            if (trip == null)
            {
                return NotFound($"Trip with id {id} not found.");
            }
            return Ok(trip);
        }
    }
}
