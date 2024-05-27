public class Customer
{
    public int Id { get; set; }
    //data never null
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    //List not null and not empty
    public List<Ticket>? Tickets { get; set; } = new List<Ticket>();
}