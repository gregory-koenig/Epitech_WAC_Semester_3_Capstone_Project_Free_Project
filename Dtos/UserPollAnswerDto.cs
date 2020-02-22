namespace Ccsrb.Dtos
{
    public class UserPollAnswerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public int AnswerId { get; set; }
    }
}