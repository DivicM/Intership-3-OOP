void Registration()
{

}



void ShowGuestMenu()
{
    Console.WriteLine("1 - Registracija\n2 - Prijava\n3 - Povratak na prethodni izbornik");
    string answer = Console.ReadLine().Trim();

    switch(answer)
    {
        case "1":

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
    Console.WriteLine("1 - Gosti\n2 - Rezervacije\n3 - Sobe\n4 - Osoblje\n5 - Izlaz iz programa");
    string answer = Console.ReadLine().Trim();
    
    switch(answer)
    {
        case "1":

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