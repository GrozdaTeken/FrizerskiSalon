namespace Application.DTOs.Returnables
{
    public class SmenaReturnable
    {
        public Guid Id { get; set; }
        public Guid FriId { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public SmenaReturnable(Guid id, Guid friId, DateTime pocetak, DateTime kraj)
        {
            Id = id;
            FriId = friId;
            Pocetak = pocetak;
            Kraj = kraj;
        }

        public SmenaReturnable() { }
    }
}