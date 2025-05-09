using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public interface IClientsService
{
    Task<List<ClientTripDTO>?> GetClientTrips(int id);
    Task<int> AddClient(ClientDTO client);

    Task<(bool IsSuccess, string Message)> AssignClientRegistration(int id, int tripId);

}