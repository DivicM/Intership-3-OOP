using System.Xml;

var guests = new List<Guest>();
var rooms = new List<Room>();
var reservations = new List<Reservation>();
var employees = new List<Employee>();
var shifts = new List<Shift>();

void Registration()
{
    Console.WriteLine("----Regstracija---\n");

    string name = ReadText("Ime: ");
    string surname = ReadText("Prezime: ");
    int birthYear = ReadInt("Godina rođenja: ", 1900, DateTime.Now.Year);
    string email = ReadUniqueEmail();
    string password = ReadPassword();

    if (!Confirm("Potvrdite registraciju"))
    {
        Console.WriteLine("Registracija prekinuta.");
        return;
    }

    guests.Add(new Guest(name, surname, birthYear, email, password));
    Console.WriteLine($"\nRegistracija uspješna. Dobrodošli, {name}!\nPritisnite bilo koju tipku za nastavak!");
    Console.ReadKey();
}

string ReadPassword()
{
    while (true)
    {
        string password = ReadText($"Lozinka (min. {Guest.MinPasswordLength} znakova): ");
        if (password.Length >= Guest.MinPasswordLength)
            return password;

        Console.WriteLine($"Lozinka mora imati barem {Guest.MinPasswordLength} znakova.");
    }
}
bool IsEmailTaken(string email)
{
    string normalized = email.Trim().ToLower();
    return guests.Any(g => g.Email == normalized);
}

string ReadUniqueEmail()
{
    while (true)
    {
        string email = ReadText("Email: ");

        if (!Guest.IsValidEmail(email))
            Console.WriteLine("Neispravan format emaila (npr. ime@mail.com).");
        else if (IsEmailTaken(email))
            Console.WriteLine("Taj email je već registriran.");
        else
            return email;
    }
}



void ShowGuestMenu()
{
    Console.Clear();
    Console.WriteLine("1 - Registracija\n2 - Prijava\n3 - Povratak na prethodni izbornik");
    string answer = Console.ReadLine().Trim();

    switch(answer)
    {
        case "1":
            Registration();
            break;
        case "2":

            break;
        case "3":
            return;
        default: Console.WriteLine("Neispravan unos"); break;
    }
}



while(true)
{
    Console.Clear();
    Console.WriteLine("1 - Gosti\n2 - Rezervacije\n3 - Sobe\n4 - Osoblje\n5 - Izlaz iz programa");
    string answer = Console.ReadLine().Trim();
    
    switch(answer)
    {
        case "1":
            ShowGuestMenu();
            break;
        case "2":

            break;
        case "3":

            break;
        case "4":

            break;
        case "5":

            return;
        default: Console.WriteLine("Pogresan unos"); break;


    }

}

string ReadText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? text = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(text))
            return text;

        Console.WriteLine("Unos ne smije biti prazan.");
    }
}

int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            return value;

        Console.WriteLine($"Unesite broj između {min} i {max}.");
    }
}

bool Confirm(string question)
{
    while (true)
    {
        Console.Write($"{question} (DA/NE): ");
        string? answer = Console.ReadLine()?.Trim().ToLower();
        if (answer == "da") return true;
        if (answer == "ne") return false;

        Console.WriteLine("Upišite y ili n.");
    }
}
