using FastEndpoints;
using TrainReservation.Api.Dtos;
using TrainReservation.Api.Mappers;
using TrainReservation.Application.Reservations.Contracts;
using TrainReservation.Application.Reservations.Models;
using TrainReservation.Domain.Entities;

namespace TrainReservation.Api.Endpoints;

public class ReservationCheckEndpoint(IReservationPlanner planner) : Endpoint<ReservationCheckRequestDto, ReservationCheckResponseDto>
{
    public override void Configure()
    {
        Post("/api/reservations/check");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ReservationCheckRequestDto request, CancellationToken cancellationToken)
    {
        ThrowIfAnyErrors();

        Train train = ReservationCheckMapper.MapToDomainTrain(request);

        ReservationResult result = planner.Check(train, request.PassengerCount, request.CanSplit);

        ReservationCheckResponseDto response = ReservationResultMapper.MapToResponse(result);

        await Send.OkAsync(response, cancellation: cancellationToken);
    }
}