public class Room : Entity
{
    public int Number { get; }
    public int Floor { get; }
    public RoomCategory Category { get; }
    public int Capacity { get; }
    public decimal PricePerNight { get; }   


    public Room(int number , int floor, RoomCategory category, int capacity, decimal pricepn)
    {
        if (number <= 0) throw new ArgumentException("Broj sobe mora biti pozitivan");
        if (capacity <= 0) throw new ArgumentException("Kapacitet mora biti pozitivan broj");
        if (pricepn <= 0) throw new ArgumentException("Cijena sobe nemoze biti 0 ili manje");
        

        Number = number;
        Floor = floor;
        Category = category;   
        Capacity = capacity;
        PricePerNight = pricepn;
    
    }




}