namespace Ccsrb.Entities
{
    public class UserPollAnswer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public int AnswerId { get; set; }
    }
}