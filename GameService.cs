class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void CreateNew(Game game)
        {
            if (game == null)
            {
                throw new ArgumentException("Game is null");
            }
            else
            {
                Console.WriteLine("A new game succsessfuly created.");
                _gameRepository.Create(game);
            }
        }

        public Game GetById(int id)
        {
            var game = _gameRepository.ReadByID(id);
            if (game == null)
            {
                throw new ArgumentException($"Game with {id} isn't found");
            }

            return game;
        }

        public List<Game> GetAll()
        {
            var games = _gameRepository.ReadAll();
            if (!games.Any())
            {
                throw new ArgumentException("Game with isn't found");
            }

            return games;
        }

        public void Update(int id, Game game)
        {
            if (game == null)
            {
                throw new ArgumentException($"No info about game");
            }
            var existingPlayer = _gameRepository.ReadByID(id);
            if (existingPlayer == null)
            {
                throw new ArgumentException($"Game with {id} isn't found for update");
            }
            _gameRepository.Update(id, game);
            Console.WriteLine($"Game with ID {id} updated successfully.");
        }

        public void Delete(int id)
        {
            var game = _gameRepository.ReadByID(id);
            if (game == null)
            {
                throw new ArgumentException($"Game with {id} isn't found for deletion");
            }

            _gameRepository.Delete(game);
        }

        public void ShowGamesForPlayer(Player player, List<Game> gameLst)
        {
            var playerGames = gameLst.Where(game => game.User1 == player || game.User2 == player).ToList();

            if (playerGames.Any())
            {
                Console.WriteLine($"Games for player {player.User.UserName}:");
                Console.WriteLine("Index\tPlayer1\t\tPlayer2\t\tWinner\t\tRating");

                foreach (var game in playerGames)
                {
                    Console.WriteLine($"{game.GameIndex}\t{game.User1.User.UserName,-10}\t{game.User2.User.UserName,-10}\t{game.WinAccount.User.UserName,-10}\t{game.Rating}");
                }
            }
            else
            {
                Console.WriteLine($"No games found for player {player.User.UserName}.");
            }
        }
    }