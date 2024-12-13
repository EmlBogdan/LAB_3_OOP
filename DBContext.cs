class DBContext
    {
        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }

        public DBContext(List<Player> players, List<Game> games)
        {
            Players = players ?? new List<Player>();
            Games = games ?? new List<Game>();
        }
    }