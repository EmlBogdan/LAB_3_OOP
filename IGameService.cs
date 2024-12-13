interface IGameService
    {
        void CreateNew(Game game);
        Game GetById(int id);
        List<Game> GetAll();
        void Update(int id, Game game);
        void Delete(int id);
        void ShowGamesForPlayer(Player player, List<Game> gameLst);
    }