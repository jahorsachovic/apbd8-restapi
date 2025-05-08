using Microsoft.Data.SqlClient;
using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public class ClientsService
{
    private readonly string _connectionString = "Data Source=localhost, 1433; User=SA; Password=YhP4sswd; Initial Catalog=apbd; Integrated Security=False; Connect Timeout=30; Encrypt=False; Trust Server Certificate=False";
    
    public async Task<List<TripDTO>?> GetClientTrips()
    {
        var trips = new List<TripDTO>();

        string command = "SELECT t.IdTrip, t.Name FROM Trip t, JOIN ";
        
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int idOrdinal = reader.GetOrdinal("IdTrip");
                    trips.Add(new TripDTO()
                    {
                        Id = reader.GetInt32(idOrdinal),
                        Name = reader.GetString(1),
                    });
                }
            }
        }
        

        return trips;
    }
}