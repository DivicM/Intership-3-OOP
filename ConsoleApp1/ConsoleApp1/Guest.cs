public class Guest : Person
{
    public string Email { get; }
    private readonly string password;
    private readonly List<Room> favourites = new();

    public Guest(string name, string surname, int birthYear,string email, string password)
        :base (name, surname, birthYear)
    {

        if (!IsValidEmail(email))
            throw new ArgumentException("Neispravan mail!");
        if (password.Length < MinPasswordLength || password == null)
            throw new ArgumentException("Lozinka mora imati barem 6 znakova");

        Email = email.Trim().ToLower();
        this.password = password;

    }
    public const int MinPasswordLength = 6;

    public IReadOnlyList<Room> Favourites => favourites;

    public bool CheckPassword(string input) => input == password;
    public bool AddFavourite(Room room)
    {
        if (favourites.Contains(room))
        {
            return false;

        }
        favourites.Add(room);

        MakeChange();
        return true;
    }
    public bool RemoveFavourite(Room room)
    {
        if (!favourites.Contains(room))
            return false;

        favourites.Remove(room);
        MakeChange();
        return true;
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var at = email.IndexOf('@');
        return at > 0                                  
            && at == email.LastIndexOf('@')            
            && email.LastIndexOf('.') > at + 1         
            && !email.EndsWith('.');
    }
}