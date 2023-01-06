using InterviewSystem.Entities.Base;

namespace InterviewSystem.Entities
{
    public class Poll : Identity
    {
        public Poll(string question, List<Answer> answers = null): this(question) =>
            (Question, Answers) = (question, answers);

        private Poll(string question) =>
            Question = question;
            

        public string Question { get; init; }
        public List<Answer>? Answers { get; init; }

        public void VoteTo(Guid id, int voteWeight = 1)
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