using TrainReservation.Application.Reservations;
using TrainReservation.Application.Reservations.Contracts;

namespace TrainReservation.Api.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTrainReservation()
        {
            services.AddScoped<IReservationPlanner, ReservationPlanner>();
            return services;

        }
    }
}
