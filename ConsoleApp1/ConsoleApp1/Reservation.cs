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

    public void ChangeDate(DateTime arrival, DateTime leaving)
    {
        DateOfArrival = arrival;
        DateOfLeaving = leaving;

        FinalPrice = NightsOfStay * Room.PricePerNight;
        MakeChange();
    }
    public void Cancel()
    {
        Status = StateOfReservation.Cancelled;
        MakeChange();
    }
    public void Complete()
    {
        Status=StateOfReservation.Completed;
        MakeChange();
    }
    public bool ViseOd48hDoDolaska() => DateOfArrival - DateTime.Now > TimeSpan.FromHours(MinHoursBeforeArrival);

    public bool Overlaps(DateTime checkIn, DateTime checkOut)
    {
        if (Status == StateOfReservation.Cancelled)
            return false;                       

        return checkIn < DateOfLeaving && checkOut > DateOfArrival;
    }

}
