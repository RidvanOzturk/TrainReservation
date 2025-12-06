using System.Text.Json.Serialization;

namespace TrainReservation.Api.Dtos;

public class WagonDto
{
    [JsonPropertyName("Ad")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Kapasite")]
    public int Capacity { get; set; }

    [JsonPropertyName("DoluKoltukAdet")]
    public int OccupiedSeats { get; set; }
}
