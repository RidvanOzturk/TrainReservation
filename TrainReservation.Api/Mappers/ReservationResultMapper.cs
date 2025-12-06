using TrainReservation.Api.Dtos;
using TrainReservation.Application.Reservations.Models;

namespace TrainReservation.Api.Mappers;

public static class ReservationResultMapper
{
    public static ReservationCheckResponseDto MapToResponse(ReservationResult result)
    {
        ReservationCheckResponseDto response = new ReservationCheckResponseDto();
        response.CanReserve = result.CanReserve;

        List<PlacementDto> placements = new List<PlacementDto>(result.Placements.Count);

        foreach (Placement placement in result.Placements)
        {
            PlacementDto placementDto = new PlacementDto();
            placementDto.WagonName = placement.WagonName;
            placementDto.PassengerCount = placement.PassengerCount;

            placements.Add(placementDto);
        }

        response.Placements = placements;

        return response;
    }
}
