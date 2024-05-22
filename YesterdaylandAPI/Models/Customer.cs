namespace YesterdaylandAPI.Models {
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
        public string Email { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
        public DateTime BirthDate { get; set; }
        public ICollection<Ticket> Tickets { get; set; }= null!;// Inicialize NOT NULL  to avoid warnings
    }
}
