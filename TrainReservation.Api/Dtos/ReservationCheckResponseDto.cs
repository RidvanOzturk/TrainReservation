using System.Text.Json.Serialization;

namespace TrainReservation.Api.Dtos;

public class ReservationCheckResponseDto
{
    [JsonPropertyName("RezervasyonYapilabilir")]
    public bool CanReserve { get; set; }

    [JsonPropertyName("YerlesimAyrinti")]
    public List<PlacementDto> Placements { get; set; } = new List<PlacementDto>();
}
