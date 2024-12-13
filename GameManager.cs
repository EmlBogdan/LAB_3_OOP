class GameManager
    {
        public static string[] steps = { "scissors", "rock", "paper" };
        private static Random random = new Random();
        private static DBContext _dbContext = new DBContext(new List<Player>(), new List<Game>());
        private static PlayerRepository _repositoryPlayer = new PlayerRepository(_dbContext.Players);
        private static PlayerService _servicePlayer = new PlayerService(_repositoryPlayer);
        private static GameRepository _repositoryGames = new GameRepository(_dbContext.Games);
        private static GameService _serviceGames = new GameService(_repositoryGames);
        private static int _gameIndex = 1;
        private static int _playerId = 1;
        public GameManager()
        {
        }

        public void Play(int id1, int id2, string gameType)
        {

            Player player1 = _servicePlayer.GetById(id1);
            Player player2 = _servicePlayer.GetById(id2);
            int stepP = random.Next(steps.Length);
            int stepO = random.Next(steps.Length);
            Console.WriteLine($"{player1.User.UserName} throw {steps[stepP]}");
            Console.WriteLine($"{player2.User.UserName} throw {steps[stepO]}");
            if (stepP == stepO)
            {
                Console.WriteLine("It's draw, let's play again");
                Play(id1, id2, gameType);
            }
            else if (stepO == 2 && stepP == 0 || stepO == 0 && stepP == 1 || stepO == 1 && stepP == 2)
            {
                Console.WriteLine($"{player1.User.UserName} win!");

                Game game = GameFactory.CreateGame(gameType, _gameIndex, player1, player2, player1, 0);
                _gameIndex++;
                player1.User.WinGame(game);
                player2.User.LoseGame(game);
                _serviceGames.CreateNew(game);
            }
            else
            {
                Console.WriteLine($"{player2.User.UserName} win!");

                Game game = GameFactory.CreateGame(gameType, _gameIndex, player1, player2, player2, 0);
                _gameIndex++;
                player1.User.LoseGame(game);
                player2.User.WinGame(game);
                _serviceGames.CreateNew(game);
            }
        }

        public GameAccount ChooseAccountType(string username, string acctype)
        {
            switch (acctype.ToLower())
            {
                case "standart":
                    return new StandartAccount(username);

                case "vip":
                    return new VIPAccount(username);

                case "winstreak":
                    return new WinStreakAccount(username);

                default:
                    Console.WriteLine("Invalid account type");
                    throw new ArgumentException("Invalid account type");
            }
        }

        public void CreateAccount(string username, string acctype)
        {
            GameAccount player = ChooseAccountType(username, acctype);
            Player user;
            user = new Player(_playerId, player);
            _playerId++;
            _servicePlayer.CreateNew(user);
        }

        public void UpdatePlayer(int id, string username, string acctype)
        {
            GameAccount newInfo = ChooseAccountType(username, acctype);
            Player newUserInfo = new Player(id, newInfo);
            _servicePlayer.Update(id, newUserInfo);
        }

        public void DeletePlayer(int id)
        {
            _servicePlayer.Delete(id);
        }

        public void ReadAllPlayers()
        {
            List<Player> lst = _servicePlayer.GetAll();
            Console.WriteLine("PlayerId\tUserName\tRating\tGames count");
            foreach (Player player in lst)
            {
                Console.WriteLine($"{player.Id,-10}\t{player.User.UserName,-10}" +
                    $"\t{player.User.CurrentRating,-10}\t{player.User.GamesCount,-10}");
            }
        }

        public void ReadAllGames()
        {
            List<Game> lst = _serviceGames.GetAll();
            Console.WriteLine("GameIndex\tPlayer1\tPlayer2\tWinner\tRating");
            foreach (Game game in lst)
            {
                Console.WriteLine($"{game.GameIndex,-10}\t{game.User1.User.UserName,-10}\t{game.User2.User.UserName,-10}" +
                    $"\t{game.WinAccount.User.UserName,-10}\t{game.Rating,-10}");
            }
        }

        public void UpdateGame(int gameId, int player1Id, int player2Id, int winnerId, int rating, string gameType)
        {
            Player player1 = _servicePlayer.GetById(player1Id);
            Player player2 = _servicePlayer.GetById(player2Id);
            Player winner = _servicePlayer.GetById(winnerId);
            Game game = GameFactory.CreateGame(gameType, gameId, player1, player2, winner, rating);
            _serviceGames.Update(gameId, game);
        }

        public void GetGamesForPlayer(int id)
        {
            Player player = _servicePlayer.GetById(id);
            _serviceGames.ShowGamesForPlayer(player, _dbContext.Games);
        }

        public void Delete(int id)
        {
            _serviceGames.Delete(id);
        }
    }