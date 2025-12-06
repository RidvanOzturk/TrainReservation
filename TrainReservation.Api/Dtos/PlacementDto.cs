using System.Text.Json.Serialization;

namespace TrainReservation.Api.Dtos;

public class PlacementDto
{
    [JsonPropertyName("VagonAdi")]
    public string WagonName { get; set; } = string.Empty;

    [JsonPropertyName("KisiSayisi")]
    public int PassengerCount { get; set; }
}
