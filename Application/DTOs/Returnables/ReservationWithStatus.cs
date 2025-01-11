namespace Application.DTOs.Returnables
{
    public class ReservationWithStatus
    {
        public Guid Id { get; set; }
        public Guid FriId { get; set; }
        public string FrizerName { get; set; }
        public DateTime Termin { get; set; }
        public bool Occupied { get; set; }
    }
}
