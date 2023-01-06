using InterviewSystem.Entities;
using System.Text;

namespace InterviewSystem.Application
{
    public class PollResults
    {
        private readonly Poll _poll;

        public PollResults(Poll poll)
        {
            _poll = poll;
        }

        public string GetView()
        {
            var stringBuilder = new StringBuilder(_poll.Question);

            stringBuilder.AppendLine("-".PadLeft(50));

            if (_poll.Answers != null && _poll.Answers.Any())
            {
                _poll.Answers.OrderBy(x => x.Percents);
                _poll.Answers.ForEach(x => stringBuilder.Append('*').AppendLine(x.ToString()));
            }
            return stringBuilder.ToString();
        }
    }
}