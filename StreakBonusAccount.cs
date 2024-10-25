class StreakBonusAccount : GameAccountBase
{
    public StreakBonusAccount(string userName) : base(userName) { }

    public override void WinGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating() + (this.GetCurrentWinStreak() * 10);
        this.Rating += rating; 
        int currentWinStreak = this.GetCurrentWinStreak();
        GamesHistory.Add(new Stat(opponentName, rating, true, game.GetType().Name, "StreakBonus", currentWinStreak));
        GamesCount++;
        IncrementWinStreak();
    }

    public override void LoseGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating();
        this.Rating -= rating; 

        GamesHistory.Add(new Stat(opponentName, rating, false, game.GetType().Name, "StreakBonus", 0));
        GamesCount++;
        ResetWinStreak();
    }
}