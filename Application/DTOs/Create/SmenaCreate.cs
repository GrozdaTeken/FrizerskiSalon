namespace Application.DTOs.Create
{
    public class SmenaCreate
    {
        public Guid FriId { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public SmenaCreate(Guid friId, DateTime pocetak, DateTime kraj)
        {
            FriId = friId;
            Pocetak = pocetak;
            Kraj = kraj;
        }

        public SmenaCreate() { }
    }
}