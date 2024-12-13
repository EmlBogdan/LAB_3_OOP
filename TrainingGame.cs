class TrainingGame : Game
    {
        public TrainingGame(int gameIndex, Player opponentName1, Player opponentName2, Player winner, int rating)
        : base(gameIndex, opponentName1, opponentName2, winner, rating)
        {
        }

        public override int RateGenerator()
        {
            return 0;
        }
    }