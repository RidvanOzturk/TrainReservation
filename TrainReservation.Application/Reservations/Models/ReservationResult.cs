namespace TrainReservation.Application.Reservations.Models;

public class ReservationResult
{
    public bool CanReserve { get; init; }
    public List<Placement> Placements { get; init; } = new();
}