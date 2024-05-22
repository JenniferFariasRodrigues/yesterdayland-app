namespace YesterdaylandAPI.Models {
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
