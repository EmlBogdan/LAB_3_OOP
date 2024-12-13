class Player
    {
        public int Id { get; set; }
        public GameAccount User { get; set; }

        public Player(int id, GameAccount user)
        {
            Id = id;
            User = user;
        }
    }