namespace Application.DTOs.Returnables
{
    public class GodisnjiReturnable
    {
        public Guid Id { get; set; }
        public Guid FriId { get; set; }
        public DateTime GodisnjiOd { get; set; }
        public DateTime GodisnjiDo { get; set; }

        public GodisnjiReturnable(Guid id, Guid friId, DateTime godisnjiOd, DateTime godisnjiDo)
        {
            Id = id;
            FriId = friId;
            GodisnjiOd = godisnjiOd;
            GodisnjiDo = godisnjiDo;
        }

        public GodisnjiReturnable()
        {
        }
    }
}