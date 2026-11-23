public abstract class Entity
{

    public Guid ID { get; } = Guid.NewGuid();
    public DateTime DateOdCreation {  get; }= DateTime.Now;
    public DateTime DateOfLastChange { get; private set; } = DateTime.Now;

    protected void MakeChange()
    {
        DateOfLastChange = DateTime.Now;
    }


}