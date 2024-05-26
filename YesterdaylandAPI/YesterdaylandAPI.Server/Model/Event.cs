public class Event
{
    public int Id { get; set; }
    //data never null
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Type { get; set; } = string.Empty;
    //List can't be empty and null
    public List<Ticket>? Tickets { get; set; } = new List<Ticket>();
}