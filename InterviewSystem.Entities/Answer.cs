using InterviewSystem.Entities.Base;

namespace InterviewSystem.Entities
{
    public class Answer : Identity
    {
        public Answer(Guid id, string version) =>
            (Id, Version) = (id, version);

        public string Version { get; init; }
        public int Votes { get; set; }
        public double Percents { get; set; }

        public void SetPercents(int totalVotes)
        {
            if (totalVotes > 0)
                Percents = Votes * 100d / totalVotes;
        }

        public override string ToString()
        {
            return $"{Version} - {Votes} ({Percents:F}%)";
        }
    }
}