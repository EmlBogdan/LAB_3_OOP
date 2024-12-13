class GameFactory
    {

        public static Game CreateGame(string gameType, int gameIndex, Player opponentName1, Player opponentName2, Player winner, int rating)
        {

            switch (gameType.ToLower())
            {
                case "standart":
                    return new StandartGame(gameIndex, opponentName1, opponentName2, winner, 0);
                case "training":
                    return new TrainingGame(gameIndex, opponentName1, opponentName2, winner, 0);
                default:
                    throw new ArgumentException("Invalid game type");
            }
        }
    }