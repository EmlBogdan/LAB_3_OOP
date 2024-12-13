class GameAccount
    {
        public string UserName { get; set; }
        private int rating = 1;
        public virtual int CurrentRating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value < 1 ? 1 : value;

            }
        }
        public int GamesCount { get; set; }

        protected List<Game> gameHistory;
        private static Random random = new Random();

        public GameAccount(string uname)
        {
            UserName = uname;
            CurrentRating = 10;
            gameHistory = new List<Game>();
        }

        public virtual void WinGame(Game g)
        {
            CurrentRating += g.Rating;
            GamesCount++;
        }

        public virtual void LoseGame(Game g)
        {
            CurrentRating -= g.Rating;
            GamesCount++;
        }
    }