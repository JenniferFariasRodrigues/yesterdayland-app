//Class to avoid serialize problem o tak data from ticket using event.

namespace YesterdaylandAPI.Server.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public int EventId { get; set; }
    }
}
