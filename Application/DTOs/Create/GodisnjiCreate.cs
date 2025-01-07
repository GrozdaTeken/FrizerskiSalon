namespace Application.DTOs.Create
{
    public class GodisnjiCreate
    {
        public Guid FriId { get; set; }
        public DateTime GodisnjiOd { get; set; }
        public DateTime GodisnjiDo { get; set; }

        public GodisnjiCreate(Guid friId, DateTime godisnjiOd, DateTime godisnjiDo)
        {
            FriId = friId;
            GodisnjiOd = godisnjiOd;
            GodisnjiDo = godisnjiDo;
        }

        public GodisnjiCreate()
        {
        }
    }
}