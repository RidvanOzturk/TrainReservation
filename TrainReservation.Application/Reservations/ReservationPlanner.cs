using TrainReservation.Application.Reservations.Contracts;
using TrainReservation.Application.Reservations.Models;
using TrainReservation.Domain.Entities;

namespace TrainReservation.Application.Reservations;

public sealed class ReservationPlanner : IReservationPlanner
{
    public ReservationResult Check(Train train, int passengerCount, bool canSplit)
    {
        if (train == null)
        {
            return Fail();
        }

        if (train.Wagons == null)
        {
            return Fail();
        }

        if (train.Wagons.Count == 0)
        {
            return Fail();
        }

        if (passengerCount <= 0)
        {
            return Fail();
        }

        if (canSplit == true)
        {
            return TrySplit(train, passengerCount);
        }

        return TrySingleWagon(train, passengerCount);
    }

    private ReservationResult TrySingleWagon(Train train, int passengerCount)
    {
        foreach (var wagon in train.Wagons)
        {
            var available = GetOnlineAvailable(wagon);

            if (available >= passengerCount)
            {
                var placements = new List<Placement>(train.Wagons.Count);

                placements.Add(new Placement
                {
                    WagonName = wagon.Name,
                    PassengerCount = passengerCount
                });

                return Ok(placements);
            }
        }

        return Fail();
    }

    private ReservationResult TrySplit(Train train, int passengerCount)
    {
        var remaining = passengerCount;
        var placements = new List<Placement>(train.Wagons.Count);

        foreach (var wagon in train.Wagons)
        {
            if (remaining == 0)
            {
                break;
            }

            var available = GetOnlineAvailable(wagon);

            if (available <= 0)
            {
                continue;
            }

            var take = Math.Min(available, remaining);

            placements.Add(new Placement
            {
                WagonName = wagon.Name,
                PassengerCount = take
            });

            remaining = remaining - take;
        }

        if (remaining == 0)
        {
            return Ok(placements);
        }

        return Fail();
    }

    private static int GetOnlineAvailable(Wagon wagon)
    {
        var maxOnlineOccupied = (int)((long)wagon.Capacity * 70 / 100);

        var available = maxOnlineOccupied - wagon.OccupiedSeats;

        if (available > 0)
        {
            return available;
        }

        return 0;
    }

    private static ReservationResult Ok(List<Placement> placements)
    {
        return new ReservationResult
        {
            CanReserve = true,
            Placements = placements
        };
    }

    private static ReservationResult Fail()
    {
        return new ReservationResult
        {
            CanReserve = false,
            Placements = new List<Placement>()
        };
    }
}
