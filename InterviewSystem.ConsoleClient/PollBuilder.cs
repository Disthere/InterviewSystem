using InterviewSystem.ConsoleClient;
using InterviewSystem.Entities;

public class PollBuilder
{
    private readonly string _question;
    private readonly List<PollAnswer> _pollAnswers;

    public PollBuilder(string question)
    {
        _question = question;
        _pollAnswers = new();  
    }
      
    public PollBuilder AddAnswer(int id, string answerVersion)
    {
        if (id > 0 && answerVersion != null)
        {
            _pollAnswers.Add(new(id, answerVersion));
        }

        return this;
    }

    public Poll Build()
    {
        return new Poll(_question)
        {
            Answers= _pollAnswers
        };
    }

    public PollResults GetResults(Poll poll) =>new PollResults(poll);
    
}