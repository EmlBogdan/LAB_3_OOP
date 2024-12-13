class StandartGame : Game
    {
        public StandartGame(int gameIndex, Player opponentName1, Player opponentName2, Player winner, int rating)
        : base(gameIndex, opponentName1, opponentName2, winner, rating)
        {
        }

        public override int RateGenerator()
        {
            Random random = new Random();
            return random.Next(10, 16);
        }
    }