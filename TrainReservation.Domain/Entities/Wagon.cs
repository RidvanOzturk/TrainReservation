namespace TrainReservation.Domain.Entities;

public class Wagon
{
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int OccupiedSeats { get; set; }
}
