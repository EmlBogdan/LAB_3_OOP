class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void CreateNew(Player player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player is null");
            }
            else if (_playerRepository.ReadById(player.Id) != null)
            {
                throw new ArgumentException("This player already exist");
            }
            else
            {
                Console.WriteLine("A new player succsessfuly created.");
                _playerRepository.Create(player);
            }
        }

        public Player GetById(int id)
        {
            var player = _playerRepository.ReadById(id);
            if (player == null)
            {
                throw new ArgumentException($"Player with {id} not found");
            }

            return player;
        }

        public List<Player> GetAll()
        {
            var players = _playerRepository.ReadAll();
            if (!players.Any())
            {
                throw new ArgumentException("No players is found");
            }

            return players;
        }

        public void Update(int id, Player player)
        {
            if (player == null)
            {
                throw new ArgumentException("No info about new player");
            }
            var existingPlayer = _playerRepository.ReadById(id);
            if (existingPlayer == null)
            {
                throw new ArgumentException($"Player with {id} not found for update");
            }
            _playerRepository.Update(id, player);
            Console.WriteLine($"Player with ID {id} updated successfully.");
        }

        public void Delete(int id)
        {
            var player = _playerRepository.ReadById(id);
            if (player == null)
            {
                throw new ArgumentException($"Player with {id} not found for deletion");
            }

            _playerRepository.Delete(player);
        }
    }