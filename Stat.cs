class Stat
{
    private string opponentName;
    private int rating;
    private bool win;
    private int gameIndex;
    private string gameType; 
    private string ratingChangeType; 
    private int winStreak; 
    private static int Index = 1;

    public Stat(string opponentName, int rating, bool win, string gameType, string ratingChangeType, int winStreak)
    {
        this.opponentName = opponentName;
        this.rating = rating;
        this.win = win;
        this.gameType = gameType;
        this.ratingChangeType = ratingChangeType; 
        this.winStreak = winStreak; 
        this.gameIndex = Index++;
    }

    public string GetOpponentName() => this.opponentName;
    public int GetRating() => this.rating;
    public bool GetWin() => this.win;
    public int GetGameIndex() => this.gameIndex;
    public string GetGameType() => this.gameType;
    public string GetRatingChangeType() => this.ratingChangeType; 
    public int GetWinStreak() => this.winStreak; 
}
