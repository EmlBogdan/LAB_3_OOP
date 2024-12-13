class StandartAccount : GameAccount
    {
        public StandartAccount(string userName) : base(userName) { }

        public override void WinGame(Game g)
        {
            base.WinGame(g);
        }

        public override void LoseGame(Game g)
        {
            base.LoseGame(g);
        }
    }