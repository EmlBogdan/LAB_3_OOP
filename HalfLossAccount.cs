class HalfLossAccount : GameAccountBase
{
    public HalfLossAccount(string userName) : base(userName) { }

    public override void WinGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating();
        this.Rating += rating; 
        int currentWinStreak = this.GetCurrentWinStreak();
        GamesHistory.Add(new Stat(opponentName, rating, true, game.GetType().Name, "HalfLoss", currentWinStreak));
        GamesCount++;
        IncrementWinStreak();
    }

    public override void LoseGame(GameBase game, string opponentName)
    {
        int rating = game.CalculateRating() / 2; 
        this.Rating -= rating; 

        GamesHistory.Add(new Stat(opponentName, rating, false, game.GetType().Name, "HalfLoss", 0));
        GamesCount++;
        ResetWinStreak();
    }
}