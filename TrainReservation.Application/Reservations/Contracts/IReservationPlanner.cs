using TrainReservation.Application.Reservations.Models;
using TrainReservation.Domain.Entities;

namespace TrainReservation.Application.Reservations.Abstractions;

public interface IReservationPlanner
{
    ReservationResult Check(Train train, int passengerCount, bool canSplit);
}
