class WinStreakAccount : GameAccount
    {
        private int winStreakCnt;

        private int WinStreakCnt
        {
            get { return winStreakCnt; }
            set
            {
                if (value > 10)
                    winStreakCnt = 10;
                else
                    winStreakCnt = value;
            }
        }

        public WinStreakAccount(string userName) : base(userName)
        {
            winStreakCnt = 0;
        }

        public override void WinGame(Game g)
        {
            WinStreakCnt++;
            if (g.Rating != 0)
            {
                CurrentRating += g.Rating + WinStreakCnt - 1;
                Console.WriteLine($"Win streak bonus rating: {WinStreakCnt - 1}");
            }
            GamesCount++;
        }


        public override void LoseGame(Game g)
        {
            WinStreakCnt = 0;
            if (g.Rating != 0)
            {
                CurrentRating -= g.Rating;
            }
            GamesCount++;
        }

    }