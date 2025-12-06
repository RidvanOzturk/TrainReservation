using TrainReservation.Application.Reservations.Models;
using TrainReservation.Domain.Entities;

namespace TrainReservation.Application.Reservations.Contracts;

public interface IReservationPlanner
{
    ReservationResult Check(Train train, int passengerCount, bool canSplit);
}
