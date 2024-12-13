interface IPlayerService
    {
        void CreateNew(Player player);
        Player GetById(int id);
        List<Player> GetAll();
        void Update(int id, Player player);
        void Delete(int id);
    }