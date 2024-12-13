class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            Console.WriteLine("=== Створення гравців ===");
            gameManager.CreateAccount("Ivan", "standart");
            gameManager.CreateAccount("Bogdan", "standart");
            gameManager.CreateAccount("Egor", "vip");
            gameManager.CreateAccount("Masha", "vip");
            gameManager.CreateAccount("Valera", "winstreak");
            gameManager.CreateAccount("Vitya", "winstreak");
            gameManager.CreateAccount("Nikita", "standart");
            
            gameManager.ReadAllPlayers();

            for (int i = 0; i < 10; i++)
            {
                gameManager.Play(1, 2, "standart");
            }

            gameManager.ReadAllPlayers();
            // gameManager.UpdatePlayer(3, "babyJohn", "standart");
            // gameManager.ReadAllPlayers();
            // gameManager.DeletePlayer(6);
            // gameManager.ReadAllPlayers();

            // gameManager.ReadAllGames();
            // gameManager.UpdateGame(5, 4, 5, 4, 23, "standart");
            // gameManager.Delete(1);
            // gameManager.ReadAllGames();
            // gameManager.GetGamesForPlayer(2);
        }
    }