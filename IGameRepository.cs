interface IGameRepository
    {
        void Create(Game game);
        Game ReadByID(int id);
        List<Game> ReadAll();
        void Update(int id, Game game);
        void Delete(Game game);
    }