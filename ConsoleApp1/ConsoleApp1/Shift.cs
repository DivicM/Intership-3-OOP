public class Shift : Entity
{
    public string Name { get; }
    public DateTime Date { get; }
    public Receptionist Receptionist { get; }
    private readonly List<Maid> maids;
    public Cook Cook { get; }

    public IReadOnlyList<Maid> Maids => maids;


    public Shift(string name, DateTime date, Receptionist receptionist,Maid firstMaid, Maid secondMaid, Cook cook)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Naziv smjene je obavezan.");

        if (receptionist == null || firstMaid== null || secondMaid== null || cook == null)
            throw new ArgumentException("Smjena mora imati sve članove.");
        if (firstMaid == secondMaid)
            throw new ArgumentException("Ista sobarica ne može biti dvaput u smjeni.");

        Name = name.Trim();
        Date = date.Date;
        Receptionist = receptionist;
        maids = new List<Maid> { firstMaid, secondMaid};
        Cook = cook;
    }
    public IEnumerable<Employee> Members
    {
        get
        {
            yield return Receptionist;
            foreach (var maid in maids)
                yield return maid;
            yield return Cook;
        }
    }
    public bool Contains(Employee employee) => Members.Contains(employee);
    public string Describe()
    {
        var result = $"Smjena: {Name} {Date:yyyy-MM-dd}";
        foreach (var member in Members)
            result += $"\n  {member.Describe()}";
        return result;
    }



}