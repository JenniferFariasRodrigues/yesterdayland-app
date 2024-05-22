 namespace YesterdaylandAPI.Models {  
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
 }