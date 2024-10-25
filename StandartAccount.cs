class StandardAccount : GameAccountBase
{
    public StandardAccount(string userName) : base(userName) { }

    public override void WinGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating();
        this.Rating += rating; 
        int currentWinStreak = this.GetCurrentWinStreak();
        GamesHistory.Add(new Stat(opponentName, rating, true, game.GetType().Name, "Standard", currentWinStreak == 0 ? 0 : currentWinStreak + 1));
        GamesCount++;
        IncrementWinStreak();
    }

    public override void LoseGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating();
        this.Rating -= rating;

        GamesHistory.Add(new Stat(opponentName, rating, false, game.GetType().Name, "Standard", 0));
        GamesCount++;
        ResetWinStreak();
    }
}