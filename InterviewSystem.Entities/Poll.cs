using System.Text;

namespace InterviewSystem.Entities
{
    public class Poll
    {
        public Poll(string question) =>
            Question = question;

        public string Question { get; }
        public List<PollAnswer> Answers { get; set; } = null!;
                
        public void VoteTo(int id, int voteWeight = 1)
        {
            var item = Answers?.SingleOrDefault(x => x.Id == id);
            if (item == null)
                return;

            item.Votes += voteWeight;

            var totalVotes = Answers?.Sum(x => x.Votes) ?? 0;
            Answers?.ForEach(x => x.SetPercents(totalVotes));

        }
    }
}