class VIPAccount : GameAccount
    {
        Random random = new Random();
        public VIPAccount(string userName) : base(userName) { }

        public override void WinGame(Game g)
        {
            if (g.Rating != 0)
            {
                int bonus = random.Next(1, 6);
                Console.WriteLine($"VIP bonus rating: {bonus}");
                CurrentRating += g.Rating + bonus;
            }
            GamesCount++;
        }

        public override void LoseGame(Game g)
        {
            if (g.Rating != 0)
            {
                int bonus = random.Next(1, 6);
                Console.WriteLine($"Rating after VIP bonus: {bonus}");
                CurrentRating -= g.Rating + random.Next(1, 6);
            }
            GamesCount++;
        }

    }