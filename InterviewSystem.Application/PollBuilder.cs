using InterviewSystem.Entities;

namespace InterviewSystem.Application
{
    public class PollBuilder
    {
        private readonly string _question;
        private readonly List<Answer> _pollAnswers;

        public PollBuilder(string question)
        {
            _question = question;
            _pollAnswers = new();
        }

        public PollBuilder AddAnswer(Guid id, string answerVersion)
        {
            if (id != null && answerVersion != null)
            {
                _pollAnswers.Add(new(id, answerVersion));
            }

            return this;
        }

        public Poll Build()
        {
            return new Poll(_question)
            {
                Answers = _pollAnswers
            };
        }

        public PollResults GetResults(Poll poll) => new PollResults(poll);

    }
}