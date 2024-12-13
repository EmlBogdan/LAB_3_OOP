class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> Players;

        public PlayerRepository(List<Player> players)
        {
            Players = players;
        }

        public void Create(Player player)
        {
            Players.Add(player);
        }

        public Player ReadById(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            return player;
        }

        public List<Player> ReadAll()
        {
            return Players;
        }

        public void Update(int id, Player player)
        {
            var existingPlayer = Players.FirstOrDefault(p => p.Id == id);
            existingPlayer.User = player.User;
        }

        public void Delete(Player player)
        {
            var playerToDelete = Players.FirstOrDefault(p => p.Id == player.Id);
            Players.Remove(playerToDelete);
        }
    }