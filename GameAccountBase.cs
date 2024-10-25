using System;
using System.Collections.Generic;

abstract class GameAccountBase
{
    protected string UserName;
    protected int CurrentRating; 
    protected int GamesCount;
    protected List<Stat> GamesHistory;
    protected int currentWinStreak; 

    public GameAccountBase(string userName)
    {
        this.UserName = userName;
        this.CurrentRating = 1; 
        this.GamesCount = 0;
        this.GamesHistory = new List<Stat>();
        this.currentWinStreak = 0;
    }

    
    public int Rating
    {
        get => CurrentRating;
        set
        {
            if (value < 1)
            {
                CurrentRating = 1;
            }
            else
            {
                CurrentRating = value;
            }
        }
    }

    public abstract void WinGame(GameBase game, string opponentName);
    public abstract void LoseGame(GameBase game, string opponentName);

    public int GetCurrentWinStreak() => this.currentWinStreak;

    protected void IncrementWinStreak() => this.currentWinStreak++;
    protected void ResetWinStreak() => this.currentWinStreak = 0;

    public void PrintStats()
    {
        Console.WriteLine($"Stats for {UserName}:");
        Console.WriteLine("| Opponent       | Rating     | Win/Lose | Game Index | Game Type        | Rating Change | Win Streak |");
        Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
        foreach (var stat in GamesHistory)
        {
            Console.WriteLine($"| {stat.GetOpponentName(),-14} | {stat.GetRating(),-10} | {(stat.GetWin() ? "Win" : "Lose"),-8} | {stat.GetGameIndex(),-10} | {stat.GetGameType(),-16} | {stat.GetRatingChangeType(),-13} | {stat.GetWinStreak(),-10} |");
        }
    }
}