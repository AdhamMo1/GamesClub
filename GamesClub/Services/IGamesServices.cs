namespace GamesClub.Services
{
    public interface IGamesServices
    {
        Task<IEnumerable<Game>> GetAllGames();
        Game? getById(int id);
        Task<Game?> Update(EditFormGamesViewModel model);
        void Create(CreateFormGamesViewModel model);
        bool Delete(int id);
    }
}
