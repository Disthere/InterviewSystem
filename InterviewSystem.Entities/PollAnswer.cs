namespace InterviewSystem.Entities
{
    public class PollAnswer
    {
        public PollAnswer(int id, string version) =>
            (Id, Version) = (id, version);

        public int Id { get; }
        public string Version { get; }
        public int Votes { get; set; }
        public double Percents { get; set; }

        public void SetPercents(int totalVotes)
        {
            if (totalVotes > 0)
                Percents = Votes * 100d / totalVotes;
        }

        public override string ToString()
        {
            return $"{Version} ({Votes} {Percents:F})";
        }
    }
}