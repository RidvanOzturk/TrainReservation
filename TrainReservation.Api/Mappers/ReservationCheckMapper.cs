using TrainReservation.Api.Dtos;
using TrainReservation.Domain.Entities;

namespace TrainReservation.Api.Mappers;

public static class ReservationCheckMapper
{
    public static Train MapToDomainTrain(ReservationCheckRequestDto request)
    {
        Train train = new Train();
        train.Name = request.Train.Name;

        List<Wagon> wagons = new List<Wagon>(request.Train.Wagons.Count);

        foreach (WagonDto wagonDto in request.Train.Wagons)
        {
            Wagon wagon = new Wagon();
            wagon.Name = wagonDto.Name;
            wagon.Capacity = wagonDto.Capacity;
            wagon.OccupiedSeats = wagonDto.OccupiedSeats;

            wagons.Add(wagon);
        }

        train.Wagons = wagons;

        return train;
    }
}
