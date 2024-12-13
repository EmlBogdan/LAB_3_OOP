abstract class Game
    {
        private int rating = 0;
        private static int gameIndex = 0;
        Random random = new Random();
        public Player User1 { get; set; }
        public Player User2 { get; set; }
        public Player WinAccount { get; set; }
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value < 0 ? 0 : value;
            }
        }
        public int GameIndex { get; set; }

        public Game(int gameIndex, Player user1, Player user2, Player winer, int rating)
        {
            GameIndex = gameIndex;
            User1 = user1;
            User2 = user2;
            Rating = RateGenerator();
            WinAccount = winer;
        }

        public abstract int RateGenerator();
    }
    