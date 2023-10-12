﻿namespace CotdQualifierRankWeb.DTOs
{
    public class GetRankDTO
    {
        public string MapUid { get; set; } = default!;
        public int CompetitionId { get; set; } = 0;
        public int ChallengeId { get; set; } = 0;
        public DateTime Date { get; set; } = default!;
        public int Time { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public bool LeaderboardIsEmpty { get; set; } = false;
    }
}
