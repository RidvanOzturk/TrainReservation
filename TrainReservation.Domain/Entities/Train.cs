namespace TrainReservation.Domain.Entities;

public class Train
{
    public string Name { get; set; } = string.Empty;
    public List<Wagon> Wagons { get; set; } = new();
}
