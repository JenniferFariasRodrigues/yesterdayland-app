namespace YesterdaylandAPI.Models {
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}