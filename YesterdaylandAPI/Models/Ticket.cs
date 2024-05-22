namespace YesterdaylandAPI.Models {
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }= string.Empty; // Inicialize NOT NULL  to avoid warnings
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
        public int EventId { get; set; }
        public Event Event { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
    }
}