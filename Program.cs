class Program
{
    static void Main(string[] args)
{
    GameAccountBase player1 = new StandardAccount("Player1");
    GameAccountBase player2 = new StreakBonusAccount("Player2");

    GameBase game1 = GameFactory.CreateGame("Standard");
    GameBase game2 = GameFactory.CreateGame("Training");
    GameBase game3 = GameFactory.CreateGame("SinglePlayer");

    player1.LoseGame(game1, "Player2");
    player2.WinGame(game1, "Player1");

    player1.LoseGame(game2, "Player2");
    player2.WinGame(game2, "Player1");

    player1.LoseGame(game3, "Player2");
    player2.WinGame(game3, "Player1");

    Console.WriteLine("\nPlayer 1 Stats:");
    player1.PrintStats();
    Console.WriteLine($"\nPlayer 1 current rating: {player1.Rating}");

    Console.WriteLine("\nPlayer 2 Stats:");
    player2.PrintStats();
    Console.WriteLine($"\nPlayer 2 current rating: {player2.Rating}");
}
}


