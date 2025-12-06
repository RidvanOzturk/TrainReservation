using FastEndpoints;
using FluentValidation;
using TrainReservation.Api.Dtos;

namespace TrainReservation.Api.Validators;

public class ReservationCheckRequestValidator : Validator<ReservationCheckRequestDto>
{
    public ReservationCheckRequestValidator()
    {
        RuleFor(x => x)
            .NotNull()
            .WithMessage("Request body is required.");

        RuleFor(x => x.Train)
            .NotNull()
            .WithMessage("Tren is required.");

        When(x => x.Train != null, () =>
        {
            RuleFor(x => x.Train.Name)
                .NotEmpty()
                .WithMessage("Tren.Ad is required.");

            RuleFor(x => x.Train.Wagons)
                .NotNull()
                .WithMessage("Tren.Vagonlar must contain at least one wagon.");

            RuleFor(x => x.Train.Wagons)
                .Must(x => x != null && x.Count > 0)
                .WithMessage("Tren.Vagonlar must contain at least one wagon.");

            RuleForEach(x => x.Train.Wagons).ChildRules(w =>
            {
                w.RuleFor(v => v.Name)
                    .NotEmpty()
                    .WithMessage("Vagonlar[].Ad is required.");

                w.RuleFor(v => v.Capacity)
                    .GreaterThan(0)
                    .WithMessage("Vagonlar[].Kapasite must be greater than 0.");

                w.RuleFor(v => v.OccupiedSeats)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Vagonlar[].DoluKoltukAdet cannot be negative.");

                w.RuleFor(v => v)
                    .Must(v => v.OccupiedSeats <= v.Capacity)
                    .WithMessage("Vagonlar[].DoluKoltukAdet cannot be greater than Kapasite.");
            });
        });

        RuleFor(x => x.PassengerCount)
            .GreaterThan(0)
            .WithMessage("RezervasyonYapilacakKisiSayisi must be greater than 0.");
    }
}
