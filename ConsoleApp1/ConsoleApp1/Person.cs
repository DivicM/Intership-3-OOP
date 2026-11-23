using System.Xml;

public abstract class Person : Entity
{

    public string Name { get; }
    public string Surname { get; }
    public int YearOfBirth {  get; }
    public string FullName => $"{Name} {Surname}";

    protected Person(string name, string surname, int birthYear)
    {

        if(string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Ime je obavezno");
        if (string.IsNullOrEmpty(surname))
            throw new ArgumentNullException("Prezime je obavezno");
        if (birthYear < 1900 || birthYear > DateTime.Now.Year)
            throw new ArgumentOutOfRangeException("Neispravno unesena godina");


        Name = name.Trim();
        Surname = surname.Trim();
        YearOfBirth = birthYear;
    }



}