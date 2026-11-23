public abstract class Employee : Person
{
    public Gender Gender { get; }
    public abstract string PositionName { get; }

    protected Employee(string name, string surname, int birthYear, Gender gender)
    : base(name, surname, birthYear)
    {
        Gender = gender;
    }

    public string Describe() => $"{PositionName}: {FullName} ({YearOfBirth})";
}

public class Receptionist : Employee
{
    protected Receptionist(string name, string surname, int birthYear, Gender gender)
    : base(name, surname, birthYear, gender) { }
    public override string PositionName => "Recepcionar";
}

public class Maid : Employee
{
    protected Maid(string name, string surname, int birthYear, Gender gender)
    : base(name, surname, birthYear, gender){}
    public override string PositionName => Gender == Gender.Female ? "Sobarica" : "Sobar"; 
}

public class Cook : Employee
{
    protected Cook(string name, string surname, int birthYear, Gender gender)
    : base(name, surname, birthYear, gender){}
    public override string PositionName => "Kuhar";
}