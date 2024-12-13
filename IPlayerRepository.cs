interface IPlayerRepository
    {
        void Create(Player player);
        Player ReadById(int id);
        List<Player> ReadAll();
        void Update(int id, Player player);
        void Delete(Player player);
    }
