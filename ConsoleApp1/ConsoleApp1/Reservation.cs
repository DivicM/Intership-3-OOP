
public class Reservation : Entity
{
    public const int MinHoursBeforeArrival = 48;

    public Guest Guest { get; }
    public Room Room { get; }
    public DateTime DateOfArrival { get; private set; }
    public DateTime DateOfLeaving { get; private set; }
    public int NightsOfStay => (DateOfLeaving - DateOfArrival).Days;
    public decimal FinalPrice { get; private set; }
    public StateOfReservation Status { get; private set; }

    public Reservation (Guest guest, Room room, DateTime dateOfArrival, DateTime dateOfLeaving)
    {

        if(guest == null) throw new ArgumentException("Gost je obavezan");

        if (room == null) throw new ArgumentException("Soba je obavezna");

        Guest = guest;
        Room = room;
        Status = StateOfReservation.Confirmed;
        ChangeDate(dateOfArrival, dateOfLeaving);
    }


    public void ChangeDate(DateTime arrival, DateTime leaving)
    {
        if (Status != StateOfReservation.Confirmed)
            throw new ArgumentException("Mogu se mijenjati samo potvrđene rezervacije.");
        if (leaving.Date <= arrival.Date)
            throw new ArgumentException("Datum odlaska mora biti nakon datuma dolaska.");

        DateOfArrival = arrival.Date;
        DateOfLeaving = leaving.Date;
        FinalPrice = NightsOfStay * Room.PricePerNight;
        MakeChange();
    }
    public bool Cancel()
    {
        if (Status != StateOfReservation.Confirmed)
            return false;

        Status = StateOfReservation.Cancelled;
        MakeChange();
        return true;
    }
    public bool Complete()
    {
        if (Status != StateOfReservation.Confirmed)
            return false;

        Status = StateOfReservation.Completed;
        MakeChange();
        return true;
    }
    public bool ViseOd48hDoDolaska() => DateOfArrival - DateTime.Now > TimeSpan.FromHours(MinHoursBeforeArrival);

    public bool Overlaps(DateTime checkIn, DateTime checkOut)
    {
        if (Status == StateOfReservation.Cancelled)
            return false;                       

        return checkIn < DateOfLeaving && checkOut > DateOfArrival;
    }

}
