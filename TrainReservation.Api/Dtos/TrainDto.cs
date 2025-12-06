using System.Text.Json.Serialization;

namespace TrainReservation.Api.Dtos;

public class TrainDto
{
    [JsonPropertyName("Ad")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Vagonlar")]
    public List<WagonDto> Wagons { get; set; } = new List<WagonDto>();
}
