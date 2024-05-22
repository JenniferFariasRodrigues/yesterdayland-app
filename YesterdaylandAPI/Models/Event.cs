 namespace YesterdaylandAPI.Models {  
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
        public DateTime Date { get; set; }
        public string Type { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
        public ICollection<Ticket> Tickets { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
    }
 }