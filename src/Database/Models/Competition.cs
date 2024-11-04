namespace CotdQualifierRank.Database.Models;

public class Competition
{
    public int Id { get; set; }

    public int NadeoCompetitionId { get; set; }

    public int NadeoChallengeId { get; set; }

    public string NadeoMapUid { get; set; }

    public DateTime Date { get; set; }

    public List<Record>? Leaderboard { get; set; }
}
