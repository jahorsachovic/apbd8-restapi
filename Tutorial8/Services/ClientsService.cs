using Microsoft.Data.SqlClient;
using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public class ClientsService : IClientsService
{
    // private readonly string _connectionString = "Data Source=localhost, 1433; User=SA; Password=YhP4sswd; Initial Catalog=apbd; Integrated Security=False; Connect Timeout=30; Encrypt=False; Trust Server Certificate=False";
    
    private readonly string _connectionString;
    
    public ClientsService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnectionString");
    }
    
    public async Task<List<ClientTripDTO>?> GetClientTrips(int id)
    {
        var trips = new List<ClientTripDTO>();

        string command = "SELECT t.IdTrip, t.Name, t.Description, t.DateFrom, t.DateTo, t.MaxPeople, ct.RegisteredAt, ct.PaymentDate FROM Trip t JOIN Client_Trip ct ON t.IdTrip = ct.IdTrip WHERE ct.IdClient = @id";
        
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            
            await conn.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int idOrdinal = reader.GetOrdinal("IdTrip");
                    trips.Add(new ClientTripDTO()
                    {
                        Id = reader.GetInt32(idOrdinal),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        DateFrom = reader.GetDateTime(3),
                        DateTo = reader.GetDateTime(4),
                        MaxPeople = reader.GetInt32(5),
                        RegisteredAt = reader.GetInt32(6),
                        PaymentDate = reader.GetInt32(7)
                    });
                }
            }
        }
        

        return trips;
    }
}