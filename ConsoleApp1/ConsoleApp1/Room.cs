public class Room : Entity
{
    public int Number { get; }
    public int Floor { get; }
    public RoomCategory Category { get; }
    public int Capacity { get; }
    public decimal PricePerNight { get; }   
}