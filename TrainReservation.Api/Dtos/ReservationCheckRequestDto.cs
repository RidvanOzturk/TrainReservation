using System.Text.Json.Serialization;

namespace TrainReservation.Api.Dtos;

public class ReservationCheckRequestDto
{
    [JsonPropertyName("Tren")]
    public TrainDto Train { get; set; } = new TrainDto();

    [JsonPropertyName("RezervasyonYapilacakKisiSayisi")]
    public int PassengerCount { get; set; }

    [JsonPropertyName("KisilerFarkliVagonlaraYerlestirilebilir")]
    public bool CanSplit { get; set; }
}
