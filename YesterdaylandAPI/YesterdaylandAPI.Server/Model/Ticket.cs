public class Ticket
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;    
    public DateTime CreateDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = new Customer();
    public int EventId { get; set; }
    public Event Event { get; set; } = new Event();
}